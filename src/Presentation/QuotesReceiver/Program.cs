// See https://aka.ms/new-console-template for more information
using Contracts.DatabaseServices;
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
using DatabaseService;
using Repository;

try
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Services.ConfigureLoggerService();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureQueueServices();
    builder.Services.ConfigureDatabaseServiceManager();
    string? connectionString = ConfigurationManager.AppSettings["DefaultConnection"];
    if (connectionString == null)
    {
        throw new Exception("Connection string not found in appsettings.json");
    }
    builder.Services.ConfigureMysqlContext(connectionString);
    builder.Services.AddAutoMapper(typeof(Program));

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
    IDatabaseServiceManager dbServiceManager = host.Services.GetRequiredService<IDatabaseServiceManager>();
    IEnumerable<InstrumentPairDto> pairs = dbServiceManager.InstrumentPairService.GetAllInstrumentPairsAsync().Result;

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
                string symbolsToSubscribe = string.Join(",", pairs.Select(p => p.QuotesPair));
                string data = "{\"userKey\":\"" + token + "\", \"symbol\":\"" + symbolsToSubscribe + "\"}";
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