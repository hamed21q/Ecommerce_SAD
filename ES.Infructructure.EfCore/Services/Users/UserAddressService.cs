using ES.Domain.Entities.Users.UserAddress;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Users
{
    public class UserAddressService : Repository<long, UserAddress>, IUserAddressService
    {
        public UserAddressService(EcommerceContext context) : base(context)
        {
        }
    }
}
