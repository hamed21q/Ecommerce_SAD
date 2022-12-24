using ES.Domain.Entities.ProductItem;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductItemService : Repository<long, ProductItem>, IProductItemService
    {
        public ProductItemService(EcommerceContext context) : base(context)
        {
        }
    }
}
