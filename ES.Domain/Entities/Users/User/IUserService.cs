using ES.Domain.DomainService;
using ES.Domain.Entities.Users.User;
using System.Linq.Expressions;

namespace ES.Domain.Entities.Users.User
{
    public interface IUserService : IRepository<long, User>
    {
        Task<User> FindByEmail(string email);
        Task SetAdmin(long id, string roleName);
    }
}
