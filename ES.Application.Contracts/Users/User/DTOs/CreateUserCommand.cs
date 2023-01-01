using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.DTOs
{
    public class CreateUserCommand 
    {
        public string EmailAddress { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public long RoleId { get; private set; }
        public long AddressId { get; private set; }
    }
}
