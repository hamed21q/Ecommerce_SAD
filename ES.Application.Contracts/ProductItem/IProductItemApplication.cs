using ES.Application.Contracts.ProductItem.DTOs;
using ES.Application.Contracts.ProductItem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductItem
{
    public interface IProductItemApplication
    {
        void Add(CreateProductItemCommand command);
        void Edit(EditProductItemCommand command);
        void Delete(long id);
        ProductItemViewModel GetBy(long id);
        List<ProductItemViewModel> GetAll();
    }
}
