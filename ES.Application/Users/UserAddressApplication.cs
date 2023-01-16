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

        public long Add(CreateUserAddressComand command)
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
            addressService.Add(address);
            unitOfWork.Save();
            var id = address.Id;
            return id;
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

        public void Delete(long id)
        {
            var address = addressService.GetBy(id);
            addressService.Delete(address);
            unitOfWork.Save();
        }

        public void Edit(EditUserAddressCommand command)
        {
            var address = addressService.GetBy(command.Id);
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
            unitOfWork.Save();
        }

        public UserAddressViewModel GetBy(long id)
        {
            var address = addressService.GetBy(id);
            return Convert(address);
        }
    }
}
