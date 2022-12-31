using ES.Domain.Entities.Products.Promotion;
using ES.Infructructure.EfCore.Base;

namespace ES.Infructructure.EfCore.Services.Products
{
    public class ProductPromotionService : Repository<long, ProductPromotion>, IProductPromotionService
    {
        public ProductPromotionService(EcommerceContext context) : base(context)
        {
        }
    }
}
