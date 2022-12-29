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
        public Country(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            this.Name = name;
        }
    }
}
