using ES.Application.Contracts.Users.UserAddress;
using ES.Domain.DomainService;
using ES.Domain.Entities.Users.UserAddress;

namespace ES.Application.Users
{
    public class UserAddressApplication : IUserAddressApplication
    {
        private readonly IUserAddressService userAddressService;
        private readonly IUnitOfWork unitOfWork;

        public UserAddressApplication(IUserAddressService userAddressService, IUnitOfWork unitOfWork)
        {
            this.userAddressService = userAddressService;
            this.unitOfWork = unitOfWork;
        }
    }
}
