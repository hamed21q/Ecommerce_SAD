using ES.Application.Contracts.Users.UserAddress;
using ES.Application.Contracts.Users.UserAddress.DTOs;
using ES.Application.Contracts.Users.UserAddress.ViewModel;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.UserAddress;

namespace ES.Application.Users
{
    public class UserAddressApplication : IUserAddressApplication
    {
        private readonly IUserAddressService addressService;
        private readonly IUnitOfWork unitOfWork;

        public UserAddressApplication(IUserAddressService userAddressService, IUnitOfWork unitOfWork)
        {
            this.addressService = userAddressService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<long> Add(CreateUserAddressComand command)
        {
            var address = new UserAddress(
                command.CountryId, 
                command.Region, 
                command.city, 
                command.PostalCode, 
                command.AddressLine1, 
                command.AddressLine2, 
                command.Street, 
                command.UnitNumber
            );
            await addressService.Add(address);
            await unitOfWork.Save();
            return address.Id;
        }

        public UserAddressViewModel Convert(UserAddress address)
        {
            return new UserAddressViewModel
            {
                CountryId = address.CountryId,
                Region = address.Region,
                city = address.City,
                PostalCode = address.PostalCode,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                Street = address.Street,
                UnitNumber = address.UnitNumber
            };
        }

        public async Task Delete(long id)
        {
            var address = await addressService.GetBy(id);
            addressService.Delete(address);
            await unitOfWork.Save();
        }

        public async Task Edit(EditUserAddressCommand command)
        {
            var address = await addressService.GetBy(command.Id);
            address.Edit(
                command.CountryId,
                command.Region,
                command.city,
                command.PostalCode,
                command.AddressLine1,
                command.AddressLine2,
                command.Street,
                command.UnitNumber
            );
            await unitOfWork.Save();
        }

        public async Task<UserAddressViewModel> GetBy(long id)
        {
            var address = await addressService.GetBy(id);
            return Convert(address);
        }
    }
}
