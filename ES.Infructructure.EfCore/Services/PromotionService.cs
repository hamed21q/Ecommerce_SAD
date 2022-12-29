using ES.Domain.Entities.Products.Promotion;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services
{
    public class PromotionService : Repository<long, ProductPromotion>, IProductPromotionService
    {
        public PromotionService(EcommerceContext context) : base(context)
        {
        }
    }
}
