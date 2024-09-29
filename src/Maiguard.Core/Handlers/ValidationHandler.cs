using FluentValidation.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Handlers
{
    public static class ValidationHandler
    {
        public static async Task<(bool IsValid, Dictionary<string, string>? Errors)> ValidateModelAsync<T>(this IValidator<T> validator, T model)
        {
            ValidationResult validationResult = await validator.ValidateAsync(model);

            if (validationResult.IsValid)
            {
                return (true, null);
            }

            Dictionary<string, string> validationFailures = new();
            foreach (ValidationFailure failure in validationResult.Errors)
            {
                if (validationFailures.ContainsKey(failure.PropertyName))
                    validationFailures[failure.PropertyName] += " | " + failure.ErrorMessage;
                else
                    validationFailures[failure.PropertyName] = failure.ErrorMessage;
            }

            return (false, validationFailures);
        }
    }
}
