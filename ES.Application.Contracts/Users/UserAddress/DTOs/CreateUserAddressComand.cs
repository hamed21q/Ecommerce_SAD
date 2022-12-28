using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Users.UserAddress.DTOs
{
    public class CreateUserAddressComand
    {
        public long CountryId { get; set; }
        public string Region { get; set; }
        public string city { get; set; }
        public long PostalCode { get;set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public long UnitNumber { get; set; }
    }
}
