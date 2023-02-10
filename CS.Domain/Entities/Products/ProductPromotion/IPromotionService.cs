using ES.Domain.DomainService;

namespace ES.Domain.Entities.Products.ProductPromotion
{
    public interface IPromotionService : IRepository<long, ProductPromotion>
    {
    }
}
