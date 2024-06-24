using DatabaseService;
using LoggerService;
using Push.Entities.Bus;
using Push.Entities.Events;
using PushService;
using PushService.EventHandlers;
using PushService.Hubs;
using QueueService;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureDatabaseServiceManager();
builder.Services.ConfigureCors(new string[] { "https://localhost:32768" });
builder.Services.ConfigureQueueServices();
builder.Services.AddTransient<QuoteReceivedEventHandler>();
builder.Services.AddTransient<IEventHandler<QuoteReceivedEvent>, QuoteReceivedEventHandler>();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
{
    throw new Exception("Connection string not found in appsettings.json");
}
builder.Services.ConfigureMysqlContext(connectionString);
builder.Services.ConfigureSignalRHandlers();
// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();

//IDatabaseServiceManager dbServiceManager = app.Services.GetRequiredService<IDatabaseServiceManager>();
//IEnumerable<InstrumentPairDto> pairs = dbServiceManager.InstrumentPairService.GetAllInstrumentPairsAsync().Result;

IEventBus eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<QuoteReceivedEvent, QuoteReceivedEventHandler>();

app.UseCors("CorsPolicy");
app.MapControllers();
app.MapHub<QuotesHub>("/hubs/quotes");

app.Run();