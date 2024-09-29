using FluentValidation;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Validators;
using Maiguard.Core.Services;
using Maiguard.Infrastructure.Repositories;
using Maiguard.Infrastructure;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

namespace Maiguard.API.Configuration
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Controller and routing configuration
            services.AddControllers();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            #endregion

            #region Services
            services.AddScoped<IResidentService, ResidentService>();
            #endregion

            #region Repositories
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            #endregion

            #region Fluent validators
            services.AddScoped<IValidator<NewResident>, NewResidentValidator>();
            #endregion

            #region Swagger configuration
            services.AddSwaggerGen(c =>
            {
                var domainXmlFile = Path.Combine(AppContext.BaseDirectory, "Maiguard.Core.xml");
                c.IncludeXmlComments(domainXmlFile);
            });
            services.AddEndpointsApiExplorer();
            services.AddFluentValidationRulesToSwagger();
            #endregion

            #region Config values
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            #endregion

            return services;
        }
    }
}