using ES.Application.Contracts.Products.ProductVariationOption.DTOs;
using ES.Application.Contracts.Products.ProductVariationOption.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariationOption
{
    public interface IProductVariationOptionApplication
    {
        void Edit(EditProductVariationOptionCommand command);
        void Add(CreateProductVariationOptionCommand command);
        List<ProductVariationOptionViewModel> GetByVariation(long variationId);
        ProductVariationOptionViewModel GetBy(long id);
        void Delete(long id);
        bool IsValid(long id);

    }
}
