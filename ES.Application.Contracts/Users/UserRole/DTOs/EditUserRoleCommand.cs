using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.Role.DTOs
{
    public class EditUserRoleCommand : CreateUserRoleCommand
    {
        public long Id { get; set; }
    }
}
