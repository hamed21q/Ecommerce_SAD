using ES.Domain.ProductCategory;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Services
{
    public class ProductCategoryService : Repository<long, ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(DbContext context) : base(context)
        {

        }
    }
}
