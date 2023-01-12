using ES.Application.Contracts.Products.ProductVariation.DTOs;
using ES.Application.Contracts.Products.ProductVariation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariation
{
    public interface IProductVariationApplication
    {

        void Add(CreateProductVariationCommand command);
        void Edit(EditProductVariationCommand command);
        ProductVariationViewModel GetBy(long id);
        List<ProductVariationViewModel> GetAll();
        List<DetailedProductVariationViewModel> GetByCategory(long categoryId);

        void Remove(long id);
        bool IsValid(long id);
    }
}
