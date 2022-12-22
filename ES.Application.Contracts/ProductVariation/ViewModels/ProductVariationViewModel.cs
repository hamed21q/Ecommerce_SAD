using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductVariation.ViewModels
{
    public class ProductVariationViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
    }
}
