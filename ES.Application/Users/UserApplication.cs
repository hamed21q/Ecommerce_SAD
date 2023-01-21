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

        public void Add(CreateUserCommand command)
        {
            long addressId = addressApplication.Add(command.address);
            CreateHash(command.Password, out byte[] salt, out byte[] pass);

            User user = new User(command.EmailAddress, command.PhoneNumber, pass, salt, addressId);
            userService.Add(user);
            unitOfWork.Save();
        }
        private void CreateHash(string password, out byte[] salt, out byte[] hashed)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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

        public bool Login(LoginUserCommand command)
        {
            var user = userService.FindByEmail(command.EmailAddress);
            if (user == null) return false;
            return VerifyPasswordHash(command.Password, user.Password, user.PasswordSalt);
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public void EditRole(long id, string roleName)
        {
            userService.SetAdmin(id, roleName);
            unitOfWork.Save();
        }
    }
}