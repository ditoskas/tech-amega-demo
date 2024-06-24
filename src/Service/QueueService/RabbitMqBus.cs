using Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Push.Entities.Bus;
using Push.Entities.Commands;
using Push.Entities.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Utilities;
using System.Configuration;
using System.Text;

namespace QueueService
{
    public sealed class RabbitMqBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly ILoggerManager _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMqBus(IMediator mediator, ILoggerManager logger, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }

        public void Publish<T>(T @event) where T : BaseEvent
        {
            ConnectionFactory factory = CreateConnectionFactory();
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                string eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);

                string message = Serializer.Serialize(@event);
                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
                _logger.LogInfo ($"Event published: [{eventName}] [{message}]");
            }
        }

        public Task SendCommand<T>(T command) where T : BaseCommand
        {
            return _mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : BaseEvent
            where TH : IEventHandler<T>
        {
            string eventName = typeof(T).Name;
            Type handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} already is registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            _logger.LogInfo($"Subscribed To: [{eventName}] with handler [{handlerType.Name}]");

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : BaseEvent
        {
            ConnectionFactory factory = CreateConnectionFactory();
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            string eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);
            AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, true, consumer);
        }

        private ConnectionFactory CreateConnectionFactory()
        {
            string host = ConfigurationManager.AppSettings["RabbitMqServer"] ?? "localhost";
            int port;
            if (!int.TryParse(ConfigurationManager.AppSettings["RabbitMqPort"], out port))
            {
                port = 5672;
            }
            string username = ConfigurationManager.AppSettings["RabbitMqUser"] ?? "dimitris";
            string password = ConfigurationManager.AppSettings["RabbitMqPassword"] ?? "2521020995";
            string directory = ConfigurationManager.AppSettings["RabbitMqDirectory"] ?? "/";

            return new ConnectionFactory()
            {
                HostName = host,
                Port = port,
                UserName = username,
                Password = password,
                VirtualHost = directory,
                DispatchConsumersAsync = true
            };
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            string eventName = @event.RoutingKey;
            string message = Encoding.UTF8.GetString(@event.Body.ToArray());

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    List<Type> subscriptions = _handlers[eventName];
                    foreach (Type subscription in subscriptions)
                    {
                        if (scope.ServiceProvider.GetService(subscription) is not IEventHandler handler) continue;

                        Type? eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                        if (eventType == null)
                        {
                            throw new Exception($"Event Type {eventName} not found");
                        }
                        object? @event = Serializer.Deserialize(message, eventType);
                        if (@event == null)
                        {
                            throw new Exception($"Fail to deserialize event, [{message}]");
                        }
                        Type concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
            }
        }
    }
}
