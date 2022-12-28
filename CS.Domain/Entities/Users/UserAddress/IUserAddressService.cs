using ES.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Users.UserAddress
{
    public interface IUserAddressService : IRepository<long, UserAddress>
    {

    }
}
