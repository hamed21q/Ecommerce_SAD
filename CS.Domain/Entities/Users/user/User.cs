using ES.Domain.Entities.ShoppingCart.ShoppingCart;
using ES.Domain.Entities.Users.Role;

namespace ES.Domain.Entities.Users.User
{
    public class User : BaseDomain
    {
        public string EmailAddress { get; private set; }
        public int PhoneNumber { get; private  set; }
        public string Password { get; private set; }
        public long RoleId { get; private set; }
        public long AddressId { get; private set; }
        public bool IsDeleted { get; set; }

        //navigation
        public virtual UserAddress.UserAddress Address { get; set; }
        public virtual List<ShoppingCart.ShoppingCart.ShoppingCart> ShoppingCarts { get; set; }
        public UserRole Role { get; set; }

        public User (string emailAddress, int phoneNumber, string password) : base()
        {
            this.ShoppingCarts = new List<ShoppingCart.ShoppingCart.ShoppingCart>();
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Password = password;
            IsDeleted = false;
        }
        public void Edit(string emailAddress, int phoneNumber, string password, long addressId)
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
