using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.ViewModels
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public UserViewModel User { get; set; }
    }
}
