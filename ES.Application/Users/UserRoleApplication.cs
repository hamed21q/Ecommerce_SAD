using ES.Application.Contracts.Users.Role;
using ES.Application.Contracts.Users.Role.DTOs;
using ES.Application.Contracts.Users.Role.ViewModels;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Users
{
    public class UserRoleApplication : IUserRoleApplication
    {
        private readonly IUserRoleService userRoleService;
        private readonly IUnitOfWork unitOfWork;

        public UserRoleApplication(IUserRoleService userRoleService, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.userRoleService = userRoleService;
        }

        public void Add(CreateUserRoleCommand command)
        {
            var role = new UserRole(command.Name);
            userRoleService.Add(role);
            unitOfWork.Save();
        }

        public void Delete(long Id)
        {
            var item = userRoleService.GetBy(Id);
            userRoleService.Delete(item);
            unitOfWork.Save();
        }

        public void Edit(EditUserRoleCommand command)
        {
            var role = userRoleService.GetBy(command.Id);
            role.Edit(command.Name);
            unitOfWork.Save();
        }

        public bool Exist(long id)
        {
            return userRoleService.Exist(r => r.Id == id);
        }

        public List<UserRoleViewModel> GetAll()
        {
            var list = userRoleService.GetAll();
            var views = new List<UserRoleViewModel>();  
            foreach (var item in list)
            {
                views.Add(new UserRoleViewModel
                {
                    Name = item.Name,
                    Id = item.Id
                });
            }
            return views;
        }

        public UserRoleViewModel GetBy(long id)
        {
            var role = userRoleService.GetBy(id);
            return new UserRoleViewModel
            {
                Id = id,
                Name = role.Name,
            };
        }
    }
}
