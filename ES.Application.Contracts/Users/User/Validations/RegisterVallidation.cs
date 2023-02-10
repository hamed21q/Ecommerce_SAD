using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Domain.Entities.Users.User;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ES.Application.Contracts.Users.User.Validations
{
    public class RegisterVallidation : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserService userService;
        public RegisterVallidation(IUserService userService)
        {
            this.userService = userService;
            RuleFor(customer => customer.Password).Equal(customer => customer.PasswordConfirmation).WithMessage("passwords doesnt matched");
            RuleFor(p => p.PhoneNumber)
                   .NotNull().WithMessage("Phone Number is required.")
                   .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                   .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                   .Matches(new Regex(@"09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}")).WithMessage("PhoneNumber not valid");
            RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address")
            .MustAsync(async (email, cancellationToken) =>
            {
                var user = await userService.FindByEmail(email);
                return user == null;
            }).WithMessage("Email already in use");
        }
    }
}
