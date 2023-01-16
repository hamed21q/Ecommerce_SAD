using ES.Domain.DomainService;
using ES.Domain.Entities.Users.User;
using System.Linq.Expressions;

namespace ES.Domain.Entities.Users.User
{
    public interface IUserService : IRepository<long, User>
    {
        User FindByEmail(string email);
    }
}
