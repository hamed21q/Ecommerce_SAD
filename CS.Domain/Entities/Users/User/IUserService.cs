using ES.Domain.DomainService;
using ES.Domain.Entities.Users.User;

namespace ES.Domain.Entities.Users.User
{
    public interface IUserService : IRepository<long, User>
    {
    }
}
