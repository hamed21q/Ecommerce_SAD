using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.ViewModels;

namespace ES.Application.Contracts.Users.User
{
    public interface IUserApplication
    {
        Task Add(CreateUserCommand command);
        Task<UserViewModel> GetBy(long id);
        Task Delete(long id);
        Task<bool> Login(LoginUserCommand command);
        Task<UserViewModel> FindByEmail(string email);
        Task EditRole(long id, string roleId);
    }
}
