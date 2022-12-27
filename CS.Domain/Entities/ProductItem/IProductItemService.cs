using ES.Domain.DomainService;
using ES.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.ProductItem
{
    public interface IProductItemService : IRepository<long, ProductItem>
    {
        Product.Product GetProduct(long productId);
        ProductCategory.ProductCategory GetCategory(long productId);
        List<long> GetProductVariations(long productItemId);
    }
}
