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
        public long ParentId { get; private set; }
        public ProductCategory Parent { get; private set; }

        public ProductCategory(string title, long parent) : base()
        {
            Title = title;
            ParentId = parent;
            IsDeleted = false;
        }
        public void Edit(long parent, string title)
        {
            ParentId = parent;
            Title = title;
        }
    }
}
