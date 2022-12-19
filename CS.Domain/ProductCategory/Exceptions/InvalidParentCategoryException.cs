using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.ProductCategory.Exceptions
{
    public class InValidParentCategoryException : Exception
    {
        public InValidParentCategoryException(string message) : base(message) { }
    }
}
