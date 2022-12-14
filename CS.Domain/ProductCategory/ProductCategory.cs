using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.ProductCategory
{
    public class ProductCategory : BaseDomain
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }

        public ProductCategory(string title) : base()
        {
            Title = title;
            IsDeleted = false;
        }
    }
}
