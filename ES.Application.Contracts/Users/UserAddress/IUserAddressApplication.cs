using ES.Application.Contracts.Users.UserAddress.DTOs;
using ES.Application.Contracts.Users.UserAddress.ViewModel;
using ES.Domain.Entities.Users.UserAddress;

namespace ES.Application.Contracts.Users.UserAddress
{
    public interface IUserAddressApplication
    {
        UserAddressViewModel Convert(Domain.Entities.Users.UserAddress.UserAddress address);
        Task<long> Add(CreateUserAddressComand command);
        Task Edit(EditUserAddressCommand command);
        Task Delete(long id);
        Task<UserAddressViewModel> GetBy(long id);
    }
}
