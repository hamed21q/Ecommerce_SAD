using ES.Application.Contracts.Products.Promotion.DTOs;
using ES.Application.Contracts.Products.Promotion.ViewModels;
using ES.Application.Contracts.Users.Country.DTOs;
using ES.Application.Contracts.Users.Country.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
