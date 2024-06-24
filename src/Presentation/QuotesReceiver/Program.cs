// See https://aka.ms/new-console-template for more information
using Contracts.DataTransferObjects;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Push.Entities.Bus;
using Push.Entities.Commands;
using QueueService;
using Shared.Utilities;
using System.Configuration;
using Websocket.Client;

try
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Services.ConfigureLoggerService();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.ConfigureQueueServices();


    string? webSocketUrl = ConfigurationManager.AppSettings["WebSocketUrl"];
    if (webSocketUrl == null)
    {
        throw new Exception("WebSocketUrl is not defined in the app.config file");
    }

    string? token = ConfigurationManager.AppSettings["WebSocketToken"];
    if (token == null)
    {
        throw new Exception("WebSocketToken is not defined in the app.config file");
    }

    using IHost host = builder.Build();

    IEventBus _eventBus = host.Services.GetRequiredService<IEventBus>();

    ManualResetEvent _quitEvent = new ManualResetEvent(false);
    Uri uri = new Uri(webSocketUrl);
    using (var client = new WebsocketClient(uri))
    {
        client.ReconnectTimeout = TimeSpan.FromSeconds(30);
        client.ReconnectionHappened.Subscribe(info =>
        {
            Console.WriteLine("Reconnection happened, type: " + info.Type);
        });
        client.MessageReceived.Subscribe(msg =>
        {
            Console.WriteLine("Message received: " + msg);
            if (msg.ToString().ToLower() == "connected")
            {
                string data = "{\"userKey\":\"" + token + "\", \"symbol\":\"BTCUSD\"}";
                client.Send(data);
            }
            else
            {
                QuoteDto? quote = Serializer.Deserialize<QuoteDto>(msg.ToString());
                if (quote != null)
                {
                    CreateQuoteCommand command = new CreateQuoteCommand(quote.symbol, quote.ts, quote.bid, quote.ask, quote.mid);
                    _eventBus.SendCommand(command);
                }
            }
        });
        _ = client.Start();
        //Task.Run(() => client.Send("{ message }"));
        _quitEvent.WaitOne();
    }
}
catch (Exception ex)
{
    Console.WriteLine("ERROR: " + ex.ToString());
}