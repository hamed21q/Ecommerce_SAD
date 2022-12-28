using ES.Domain.Entities.Promotion;
using ES.Infructructure.EfCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Infructructure.EfCore.Services
{
    public class PromotionService : Repository<long, Promotion>, IPromotionService
    {
        public PromotionService(EcommerceContext context) : base(context)
        {
        }
    }
}
