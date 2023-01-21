using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.ViewModels;
using ES.Domain.Entities.Users.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User
{
    public interface IUserApplication
    {
        void Add(CreateUserCommand command);
        void Edit(EditUserCommand command);
        UserViewModel GetBy(long id);
        void Delete(long id);
        bool Login(LoginUserCommand command);
        UserViewModel FindByEmail(string email);
        void EditRole(long id, string roleId);
    }
}
