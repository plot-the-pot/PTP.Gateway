using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, ErrorSubCodes errorSubCode)
        {
            return FluentValidation.DefaultValidatorOptions.WithErrorCode(rule, ((int)errorSubCode).ToString());
        }
    }
}
