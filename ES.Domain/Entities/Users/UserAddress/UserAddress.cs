using ES.Domain.Entities.Users.Country;
using ES.Domain.Entities.Users;

namespace ES.Domain.Entities.Users.UserAddress
{
    public class UserAddress : BaseDomain
    {
        public long CountryId { get; private set; }
        public string Region { get; private set; }
        public string City { get; private set; }
        public long PostalCode { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string Street { get; private set; }
        public long UnitNumber { get; private set; }

        //navigation 
        public virtual Country.Country Coutnry { get; set; }
        public virtual List<User.User> Users { get; set; }
        public UserAddress(
            long countryId, 
            string region, 
            string city, 
            long postalCode, 
            string addressLine1, 
            string addressLine2, 
            string street, 
            long unitNumber
        ) : base()
        {
            CountryId = countryId;
            Region = region;
            this.City = city;
            PostalCode = postalCode;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Street = street;
            UnitNumber = unitNumber;
        }
        public void Edit(
            long countryId,
            string region,
            string city,
            long postalCode,
            string addressLine1,
            string addressLine2,
            string street,
            long unitNumber
        )
        {
            CountryId = countryId;
            Region = region;
            this.City = city;
            PostalCode = postalCode;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Street = street;
            UnitNumber = unitNumber;
        }
    }
}
