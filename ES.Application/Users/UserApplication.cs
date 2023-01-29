using ES.Application.Contracts.Users.User;
using ES.Application.Contracts.Users.User.DTOs;
using ES.Application.Contracts.Users.User.DTOs.Login;
using ES.Application.Contracts.Users.User.DTOs.Register;
using ES.Application.Contracts.Users.User.ViewModels;
using ES.Application.Contracts.Users.UserAddress;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.User;
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

        public async Task Add(CreateUserCommand command)
        {
            long addressId = await addressApplication.Add(command.address);
            CreateHash(command.Password, out byte[] salt, out byte[] pass);

            User user = new User(command.EmailAddress, command.PhoneNumber, pass, salt, addressId);
            await userService.Add(user);
            await unitOfWork.Save();
        }
        private void CreateHash(string password, out byte[] salt, out byte[] hashed)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task Delete(long id)
        {
            var user = await userService.GetBy(id);
            user.Delete();
            await unitOfWork.Save();
        }

        public async Task<UserViewModel> FindByEmail(string email)
        {
            var user = await userService.FindByEmail(email);
            return await GetBy(user.Id);
        }

        public async Task<UserViewModel> GetBy(long id)
        {
            var user = await userService.GetBy(id);
            return new UserViewModel
            {
                Id = id,
                EmailAddress = user.EmailAddress,
                Role = user.Role.Name,
                AddressViewModel = addressApplication.Convert(user.Address),
                RoleId = user.RoleId
            };
        }

        public async Task<bool> Login(LoginUserCommand command)
        {
            var user = await userService.FindByEmail(command.EmailAddress);
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

        public async Task EditRole(long id, string roleName)
        {
            await userService.SetAdmin(id, roleName);
            await unitOfWork.Save();
        }
    }
}