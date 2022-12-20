using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Application.Contracts.ProductCategory.DTOs;
using ES.Application.Contracts.ProductCategory.ViewModels;

namespace ES.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Add(CreateProductCategoryCommand command);
        List<ProductCategoryViewModel> GetAll();
        bool IsValid(long id);
        ProductCategoryViewModel GetBy(long id);
        void Rename(RenameProductCategoryCommand command);
        void Remove(long id);
        void Activate(long id);
    }
}
