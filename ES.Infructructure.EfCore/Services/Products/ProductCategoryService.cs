using ES.Domain.Entities.Products.ProductCategory;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductCategoryService : Repository<long, ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(EcommerceContext context) : base(context)
        {

        }
    }
}
