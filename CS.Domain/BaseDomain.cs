using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class BaseDomain
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        protected BaseDomain() 
        {
            CreationDate= DateTime.Now;
        }
    }
}
