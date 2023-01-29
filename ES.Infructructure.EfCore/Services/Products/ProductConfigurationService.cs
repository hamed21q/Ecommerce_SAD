using ES.Domain.Entities.Products.ProductConfiguration;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;

namespace ES.Infructructure.EfCore.Services.Products.Products
{
    public class ProductConfigurationService : Repository<long, ProductConfiguration>, IProductConfigurationService
    {
        private readonly EcommerceContext context;
        public ProductConfigurationService(EcommerceContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ProductConfiguration>> GetConfigsByProductItem(long productItemId)
        {
            return await context.productConfigurations.Where(c => c.ProductItemId == productItemId).ToListAsync();
        }
    }
}
