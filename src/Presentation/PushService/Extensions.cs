using PushService.SignalRHandlers;

namespace PushService
{
    public static class Extensions
    {
        public static void ConfigureSignalRHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IQuoteSignalRHandler, QuoteSignalRHandler>();
        }

        public static void ConfigureCors(this IServiceCollection services, string[] hostsToAllow)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyMethod()
                                                                  .AllowAnyHeader()
                                                                  .AllowCredentials()
                                                                  .WithOrigins(hostsToAllow));
            });
        }
    }
}
