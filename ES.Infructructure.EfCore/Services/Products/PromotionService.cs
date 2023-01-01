using ES.Domain.Entities.Products.Promotion;
using ES.Domain.Entities.Users.Country;
using ES.Infructructure.EfCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Products
{
    public class PromotionService : Repository<long, Promotion>, IPromotionService
    {
        public PromotionService(EcommerceContext context) : base(context)
        {

        }
    }
}
