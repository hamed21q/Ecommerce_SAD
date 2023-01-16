using ES.Application.Contracts.Users.UserAddress.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.DTOs.Register
{
    public class CreateUserCommand
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public CreateUserAddressComand address { get; set; }

    }
}
