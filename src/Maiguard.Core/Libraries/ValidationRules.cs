﻿using FluentValidation;
using Maiguard.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Libraries
{
    /// <summary>
    /// </summary>
    public static class ValidationRules
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> CommunityIdValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(12).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.CommunityId).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.CommunityId);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> NameValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(50).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.Name).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.Name);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> EmailValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.Email).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.Email);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> AddressValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.Address).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.Address);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> ResidentIdValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(12).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.ResidentId).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.ResidentId);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> PhoneNumberValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(14).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.PhoneNumber).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.PhoneNumber);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> AdminIdValidator<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.IsRequired)
                .MaximumLength(12).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.AdminId).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.AdminId);
        }
    }

}