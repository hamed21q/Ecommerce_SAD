using ES.Application.Contracts.Users.UserAddress.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.User.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public UserAddressViewModel AddressViewModel { get; set; }
        public long RoleId { get; set; }
    }
}
