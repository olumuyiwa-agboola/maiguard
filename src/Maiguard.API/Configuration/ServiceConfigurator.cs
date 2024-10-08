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
using Maiguard.Core.Factories;
using Maiguard.Core.Abstractions.IFactories;

namespace Maiguard.API.Configuration
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Controller, HTTP and routing configuration
            services.AddControllers();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddHttpContextAccessor();
            #endregion

            #region Services
            services.AddScoped<IResidentService, ResidentService>();
            #endregion

            #region Factories
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
            #endregion

            #region Repositories
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            #endregion

            #region Validators
            services.AddScoped<IValidator<ResidentActivationRequest>, ResidentActivationRequestValidator>();
            services.AddScoped<IValidator<ResidentRegistrationRequest>, ResidentRegistrationRequestValidator>();
            services.AddScoped<IValidator<ResidentDeactivationRequest>, ResidentDeactivationRequestValidator>();
            services.AddScoped<IValidator<InvitationCodeGenerationRequest>, InvitationCodeGenerationRequestValidator>();
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