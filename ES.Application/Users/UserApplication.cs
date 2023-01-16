using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.ViewModels;
using ES.Application.Contracts.Users.UserAddress;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.User;
using ES.Domain.Entities.Users.UserAddress;
using System.Linq.Expressions;
using System.Security.Cryptography;

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

        public void Add(RegisterDTO command)
        {
            long addressId = addressApplication.Add(command.address);
            User user = new User(command.EmailAddress, command.PhoneNumber, command.Password, addressId);
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
            
        }

        public UserViewModel FindByEmail(string email)
        {
            var user = userService.FindByEmail(email);
            return GetBy(user.Id);
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

        public bool Login(LoginDTO command)
        {
            var user = userService.FindByEmail(command.EmailAddress);
            if (user == null) return false;
            return user.Password.SequenceEqual(command.Password);
        }
    }
}
