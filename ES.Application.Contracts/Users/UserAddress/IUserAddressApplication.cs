using ES.Application.Contracts.Users.UserAddress.DTOs;
using ES.Application.Contracts.Users.UserAddress.ViewModel;

namespace ES.Application.Contracts.Users.UserAddress
{
    public interface IUserAddressApplication
    {
        UserAddressViewModel Convert(Domain.Entities.Users.UserAddress.UserAddress address);
        long Add(CreateUserAddressComand command);
        void Edit(EditUserAddressCommand command);
        void Delete(long id);
        UserAddressViewModel GetBy(long id);
    }
}
