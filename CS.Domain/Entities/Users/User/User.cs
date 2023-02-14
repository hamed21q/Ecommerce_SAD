using ES.Domain.Entities.ShoppingCart.ShoppingCart;
using ES.Domain.Entities.Users.Role;

namespace ES.Domain.Entities.Users.User
{
    public class User : BaseDomain
    {
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private  set; }
        public byte[] Password { get; private set; }
        public byte[] PasswordSalt { get; set; }
        public long RoleId { get; private set; }
        public long AddressId { get; private set; }
        public bool IsDeleted { get; set; }

        //navigation
        public virtual UserAddress.UserAddress Address { get; set; }
        public virtual UserRole Role { get; set; }

        public User (
            string emailAddress,
            string phoneNumber, 
            byte[] password,
            byte[] salt,
            long addressId) : base()
        {
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Password = password;
            IsDeleted = false;
            AddressId = addressId;
            RoleId = 3;
            PasswordSalt = salt;
        }
        protected User()
        {

        }
        public void Edit(string emailAddress, string phoneNumber, byte[] password, long addressId)
        {
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            AddressId = addressId;
            Password = password;
        }
        public void EditRole(long roleId)
        {
            RoleId = roleId;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
