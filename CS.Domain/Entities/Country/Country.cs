using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Country
{
    public class Country:BaseDomain
    {
        public string Name { get;private set; }
        public Country(string name)
        {
            Name = name; 
        }
    }
}
