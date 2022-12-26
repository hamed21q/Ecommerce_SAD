using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductCategory
{
    public interface IProductCategoryService : IRepository<long, ProductCategory>
    {
    }
}
