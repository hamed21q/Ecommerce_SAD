using ES.Domain.Entities.Users.User;
using ES.Infructructure.EfCore.Base;
using System.Linq.Expressions;

namespace ES.Infructructure.EfCore.Services.Users
{
    public class UserService : Repository<long, User>, IUserService
    {
        private readonly EcommerceContext context;
        public UserService(EcommerceContext context) : base(context)
        {
            this.context = context;
        }

        public User FindByEmail(string email)
        {
            return context.users.Where(u => u.EmailAddress.Equals(email)).First();
        }

        public void SetAdmin(long id, string name)
        {
            var user = GetBy(id);
            var roleId = context.userRoles.Where(r => r.Name == name).First();
            if (roleId == null)
            {
                throw new ArgumentException();
            }
            user.EditRole(roleId.Id);
        }
    }
}
