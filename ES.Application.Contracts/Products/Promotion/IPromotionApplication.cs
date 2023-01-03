using ES.Application.Contracts.Products.Promotion.DTOs;
using ES.Application.Contracts.Products.Promotion.ViewModels;

namespace ES.Application.Contracts.Products.Promotion
{
    public interface IPromotionApplication
    {
        void Add(CreatePromotionCommand command);
        void Edit(EditPromotionCommand command);
        PromotionViewmodels GetdBy(long id);
        List<PromotionViewmodels> GetAll();
        void Delete(long id);
    }
}
