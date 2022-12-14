using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.ProductCategory
{
    public interface IProductCategoryService : IRepository<long, ProductCategory>
    {

    }
}
