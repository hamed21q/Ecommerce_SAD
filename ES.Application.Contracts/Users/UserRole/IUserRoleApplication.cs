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
        void Add(CreateUserRoleCommand command);
        void Edit(EditUserRoleCommand command);
        void Delete(long Id);
        bool Exist(long id);
        UserRoleViewModel GetBy(long id);
        List<UserRoleViewModel> GetAll();
    }
}
