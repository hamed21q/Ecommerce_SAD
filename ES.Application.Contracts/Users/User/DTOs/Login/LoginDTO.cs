using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.DTOs.Login
{
    public class LoginDTO
    {
        public string EmailAddress { get; set; } = string.Empty;
        public byte[] Password { get; set; } 
    }
}
