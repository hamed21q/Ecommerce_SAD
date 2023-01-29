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
        Task Edit(EditProductVariationOptionCommand command);
        Task Add(CreateProductVariationOptionCommand command);
        Task<List<ProductVariationOptionViewModel>> GetByVariation(long variationId);
        Task<ProductVariationOptionViewModel>GetBy(long id);
        Task Delete(long id);
        Task<bool> IsValid(long id);

    }
}
