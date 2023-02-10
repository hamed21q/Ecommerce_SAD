using ES.Domain.Entities.Users.User;

namespace ES.Domain.Entities.Users.Role
{
    public class UserRole : BaseDomain
    {
        public string Name { get; private set; }


        //navigation
        public virtual List<User.User> Users { get; set; }
        public UserRole(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            Name = name;
        }

    }
}
