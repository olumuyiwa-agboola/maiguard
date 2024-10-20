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
using Maiguard.Core.AppSettings;

namespace Maiguard.API.Configuration
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Config values
            services.Configure<RedisCacheSettings>(configuration.GetSection(RedisCacheSettings.Options));
            services.Configure<DbConnectionSettings>(configuration.GetSection(DbConnectionSettings.ConnectionStrings));
            services.Configure<EmailClientConfiguration>(configuration.GetSection(EmailClientConfiguration.Options));
            #endregion

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
            services.AddScoped<IEmailService, EmailService>();
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

            #region Swagger configuration
            services.AddSwaggerGen(c =>
            {
                var domainXmlFile = Path.Combine(AppContext.BaseDirectory, "Maiguard.Core.xml");
                c.IncludeXmlComments(domainXmlFile);
            });
            services.AddEndpointsApiExplorer();
            services.AddFluentValidationRulesToSwagger();
            #endregion

            return services;
        }
    }
}