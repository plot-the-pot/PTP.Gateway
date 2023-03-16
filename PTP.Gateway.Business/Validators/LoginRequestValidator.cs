using FluentValidation;
using PTP.Gateway.Business.Models;
using PTP.Gateway.Business.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTP.Gateway.Business.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            RuleFor(m => m.EmailAddress).NotEmpty().EmailAddress().WithErrorCode(ErrorSubCodes.InvalidEmailAddress);
            RuleFor(m => m.Password).NotEmpty().MinimumLength(8).MaximumLength(32).WithErrorCode(ErrorSubCodes.InvalidPasswordFormat);
        }
    }
}
