using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ProductCategory.Exceptions
{
    public class EmptyTitleException : Exception
    {
        public EmptyTitleException(string message) : base(message) { }
    }
}
