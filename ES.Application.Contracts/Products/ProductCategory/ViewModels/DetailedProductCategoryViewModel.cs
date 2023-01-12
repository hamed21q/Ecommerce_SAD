using ES.Domain.Entities.Products.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductCategory.ViewModels
{
    public class DetailedProductCategoryViewModel : ProductCategoryViewModel
    {
        public List<ProductCategoryViewModel> childCategories { get; set; }
    }
}