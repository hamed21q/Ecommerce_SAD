using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.Product.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
