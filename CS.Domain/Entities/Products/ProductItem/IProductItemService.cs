using ES.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Products.ProductItem
{
    public interface IProductItemService : IRepository<long, ProductItem>
    {
        ProductItem GetByEXP(Expression<Func<ProductItem, bool>> expr);
    }
}
