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

        Task Add(CreateProductVariationCommand command);
        Task Edit(EditProductVariationCommand command);
        Task<ProductVariationViewModel> GetBy(long id);
        Task<List<ProductVariationViewModel>> GetAll();
        Task<List<DetailedProductVariationViewModel>> GetByCategory(long categoryId);

        Task Remove(long id);
        Task<bool> IsValid(long id);
    }
}
