using Api;
using Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using NLog;
using LoggerService;

var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureQuotesProvider();
//builder.Services.ConfigureCors(new string[] { "http://localhost:8083" });
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyMethod()
                                                      .AllowAnyHeader()
                                                      .AllowAnyOrigin());
});
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

//string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
string? connectionString = "server=db;database=amega;user=amega;password=Am3ga!;";
if (connectionString == null)
{
    throw new Exception("Connection string not found in appsettings.json");
}

builder.Services.ConfigureMysqlContext(connectionString);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(opt => { });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
