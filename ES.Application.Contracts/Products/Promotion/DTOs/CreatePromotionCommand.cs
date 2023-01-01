using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.Promotion.DTOs
{
    public class CreatePromotionCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPromotion { get; set; }
    }
}
