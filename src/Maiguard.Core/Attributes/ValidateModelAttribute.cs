using FluentValidation;
using FluentValidation.Results;
using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Models.APIResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Attributes
{
    /// <summary>
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var serviceProvider = context.HttpContext.RequestServices;

            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null)
                {
                    context.Result = new BadRequestObjectResult("Request body cannot be null.");
                    return;
                }

                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
                var validator = serviceProvider.GetService(validatorType) as IValidator;

                if (validator != null)
                {
                    ValidationResult validationResult = validator.Validate(new ValidationContext<object>(argument));

                    if (!validationResult.IsValid)
                    {
                        Dictionary<string, string> validationFailures = new();
                        foreach (ValidationFailure failure in validationResult.Errors)
                        {
                            if (validationFailures.ContainsKey(failure.PropertyName))
                                validationFailures[failure.PropertyName] += " | " + failure.ErrorMessage;
                            else
                                validationFailures[failure.PropertyName] = failure.ErrorMessage;
                        }

                        var httpContext = context.HttpContext;
                        string instance = httpContext!.Request!.Path.Value;
                        var validationProblemDetails = new ProblemDetails()
                        {
                            Status = (int)HttpStatusCode.BadRequest,
                            Instance = instance,
                            Title = "One or more validation errors occured.",
                            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                        };

                        validationProblemDetails.Extensions["errors"] = validationFailures;

                        context.Result = new BadRequestObjectResult(validationProblemDetails);

                        return;
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
