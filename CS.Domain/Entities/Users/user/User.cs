using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Users.user
{
    public class User : BaseDomain
    {
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }

     public User (string emailAddress, int phoneNumber, string password) : base()
        {
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Password = password;

        }
    }
}
