using ES.Application.Contracts.Users.User.DTOs.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.Validations
{
    public class RegisterVallidation : AbstractValidator<CreateUserCommand>
    {
        public RegisterVallidation()
        {
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(customer => customer.Password).Equal(customer => customer.PasswordConfirmation).WithMessage("passwords doesnt matched");
            RuleFor(p => p.PhoneNumber)
                   .NotNull().WithMessage("Phone Number is required.")
                   .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                   .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                   .Matches(new Regex(@"09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}")).WithMessage("PhoneNumber not valid");
        }
    }
}
