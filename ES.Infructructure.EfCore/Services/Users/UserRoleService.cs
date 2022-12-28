using ES.Domain.Entities.Users.Role;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Users
{
    public class UserRoleService : Repository<long, UserRole>, IUserRoleService
    {
        public UserRoleService(EcommerceContext context) : base(context)
        {
        }
    }
}
