using ES.Application.Contracts.Product.DTOs;
using ES.Application.Contracts.Product.ViewModels;
using ES.Application.Contracts.ProductCategory.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Add(CreateProductCommand command);
        bool IsValid(long id);
        void Edit(EditProductCommand command);
        ProductViewModel GetBy(long id);
        List<ProductViewModel> GetByCategory(long id);
        void Delete(long id);
    }
}
