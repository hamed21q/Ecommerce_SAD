using ES.Domain.Entities.Products.ProductPromotion;
using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Products
{
    public class ProductPromotionService : Repository<long, ProductPromotion>, IPromotionService
    {
        public ProductPromotionService(EcommerceContext context) : base(context)
        {

        }
    }
}
