using ES.Application.Contracts.Users.UserAddress.DTOs;
using ES.Application.Contracts.Users.UserAddress.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.DTOs.Register
{
    public class RegisterDTO
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Password { get; set; }
        public CreateUserAddressComand address { get; set; }
    }
}
