using ES.Domain.Entities.Users.UserAddress;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Users
{
    public class UserAddressService : Repository<long, UserAddress>, IUserAddressService
    {
        public UserAddressService(EcommerceContext context) : base(context)
        {
        }
    }
}
