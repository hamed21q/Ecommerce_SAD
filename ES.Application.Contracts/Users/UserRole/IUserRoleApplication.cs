using ES.Application.Contracts.Users.Role.DTOs;
using ES.Application.Contracts.Users.Role.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.Role
{
    public interface IUserRoleApplication
    {
        Task Add(CreateUserRoleCommand command);
        Task Edit(EditUserRoleCommand command);
        Task Delete(long Id);
        Task<bool> Exist(long id);
        Task<UserRoleViewModel> GetBy(long id);
        Task<List<UserRoleViewModel>> GetAll();
    }
}
