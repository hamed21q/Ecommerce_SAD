using ES.Application.Contracts.ProductVariation.DTOs;
using ES.Application.Contracts.ProductVariation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductVariation
{
    public interface IProductVariationApplication
    {
        ProductVariationViewModel GetBy(long id);
        void Add(CreateProductVariationCommand command);
        void Edit(EditProductVariationCommand command);
        List<ProductVariationViewModel> GetAll();
        void Remove(long id);
        bool IsValid(long id);
    }
}
