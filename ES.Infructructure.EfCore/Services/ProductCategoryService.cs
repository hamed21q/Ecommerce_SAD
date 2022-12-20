using ES.Domain.Entities.ProductCategory;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductCategoryService : Repository<long, ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(EcommerceContext context) : base(context)
        {
        }
    }
}
