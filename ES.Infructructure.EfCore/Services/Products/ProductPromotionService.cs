using ES.Domain.Entities.Products.Promotion;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services.Products
{
    public class ProductPromotionService : Repository<long, ProductPromotion>, IProductPromotionService
    {
        public ProductPromotionService(EcommerceContext context) : base(context)
        {
        }
    }
}
