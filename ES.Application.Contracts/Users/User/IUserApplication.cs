using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
