using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Application.Contracts.Users.User.DTOs.Register;

namespace ES.Application.Contracts.Users.User.DTOs
{
    public class EditUserCommand : CreateUserCommand
    {
        public long Id { get; set; }
    }
}
