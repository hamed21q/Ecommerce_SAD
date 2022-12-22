using ES.Application.Contracts.ProductVariationOption.DTOs;
using ES.Application.Contracts.ProductVariationOption.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductVariationOption
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
