using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.ProductCategory
{
    public interface IProductCategoryRepository
    {
        void Add(ProductCategory productCategory);
        ProductCategory GetBy(long id);
        List<ProductCategory> GetAll();
    }
}
