namespace Maiguard.API.Configuration
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add controllers
            services.AddControllers();
            
            // Add custom routing configuration
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            // Add Swagger docuemtation configuration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
