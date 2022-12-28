using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.UserAddress.DTOs
{
    public class EditUserAddressCommand : CreateUserAddressComand
    {
        public long Id { get; set; }
    }
}
