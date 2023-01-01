using ES.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Products.ProductPromotion
{
    public interface IPromotionService : IRepository<long, ProductPromotion>
    {
    }
}
