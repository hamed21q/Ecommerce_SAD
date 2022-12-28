namespace ES.Domain.Entities.Users.Role
{
    public class UserRole : BaseDomain
    {
        public string Name { get; private set; }

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
