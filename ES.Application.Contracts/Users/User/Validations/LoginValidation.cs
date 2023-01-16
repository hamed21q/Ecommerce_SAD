using ES.Application.Contracts.Users.User.DTOs.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.Validations
{
    public class LoginValidation : AbstractValidator<LoginUserCommand>
    {
        private readonly IUserApplication userApplication;

        public LoginValidation(IUserApplication userApplication)
        {
            this.userApplication = userApplication;
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
