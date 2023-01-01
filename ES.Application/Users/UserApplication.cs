using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.ViewModels;
using ES.Application.Contracts.Users.UserAddress;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.User;

namespace ES.Application.Users
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserAddressApplication addressApplication;
        public UserApplication(IUserService userService, IUnitOfWork unitOfWork, IUserAddressApplication addressApplication)
        {
            this.userService = userService;
            this.unitOfWork = unitOfWork;
            this.addressApplication = addressApplication;
        }

        public void Add(CreateUserCommand command)
        {
            var user = new User(command.EmailAddress, command.PhoneNumber, command.Password);
            userService.Add(user);
            unitOfWork.Save();
        }

        public void Delete(long id)
        {
            var user = userService.GetBy(id);
            user.Delete();
            unitOfWork.Save();
        }

        public void Edit(EditUserCommand command)
        {
            var user = userService.GetBy(command.Id);
            user.Edit(command.EmailAddress, command.PhoneNumber, command.Password, command.AddressId);
            unitOfWork.Save();
        }

        public UserViewModel GetBy(long id)
        {
            var user = userService.GetBy(id);
            return new UserViewModel
            {
                Id = id,
                EmailAddress = user.EmailAddress,
                Role = user.Role.Name,
                AddressViewModel = addressApplication.Convert(user.Address),
                RoleId = user.RoleId
            };
        }
    }
}
