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

        public async Task Add(CreateUserRoleCommand command)
        {
            var role = new UserRole(command.Name);
            await userRoleService.Add(role);
            await unitOfWork.Save();
        }

        public async Task Delete(long Id)
        {
            var item = await userRoleService.GetBy(Id);
            userRoleService.Delete(item);
            await unitOfWork.Save();
        }

        public async Task Edit(EditUserRoleCommand command)
        {
            var role = await userRoleService.GetBy(command.Id);
            role.Edit(command.Name);
            unitOfWork.Save();
        }

        public async Task<bool> Exist(long id)
        {
            return await userRoleService.Exist(r => r.Id == id);
        }

        public async Task<List<UserRoleViewModel>> GetAll()
        {
            var list =await userRoleService.GetAll();
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

        public async Task<UserRoleViewModel> GetBy(long id)
        {
            var role = await userRoleService.GetBy(id);
            return new UserRoleViewModel
            {
                Id = id,
                Name = role.Name,
            };
        }
    }
}
