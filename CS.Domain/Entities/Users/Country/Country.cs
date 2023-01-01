using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Users.Country
{
    public class Country : BaseDomain
    {

        public string Name { get; set; }

        //navigation
        public virtual List<UserAddress.UserAddress> Addresses { get; set; }
        public Country(string name)
        {
            Addresses = new List<UserAddress.UserAddress>();
            Name = name;
        }
        public void Edit(string name)
        {
            this.Name = name;
        }
    }
}
