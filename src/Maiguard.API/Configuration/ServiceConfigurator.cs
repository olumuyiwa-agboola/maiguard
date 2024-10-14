using FluentValidation;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Validators;
using Maiguard.Core.Services;
using Maiguard.Infrastructure.Repositories;
using Maiguard.Infrastructure;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Maiguard.Core.Factories;
using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Maiguard.API.Configuration
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Controller, HTTP and routing configuration
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateModelAttribute>();
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddHttpContextAccessor();
            #endregion

            #region Services
            services.AddScoped<IResidentService, ResidentService>();
            services.AddScoped<IAccessCodeService, AccessCodeService>();
            #endregion

            #region Factories
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
            #endregion

            #region Repositories
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            #endregion

            #region Validators
            services.AddValidatorsFromAssemblyContaining<ResidentRegistrationRequestValidator>();
            #endregion

            #region Cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "Maiguard_";
            });
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