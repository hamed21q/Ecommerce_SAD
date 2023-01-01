using ES.Domain.Entities.Users.User;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Users
{
    public class UserService : Repository<long, User>, IUserService
    {
        public UserService(EcommerceContext context) : base(context)
        {
        }
    }
}
