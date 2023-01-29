using ES.Application.Contracts.Products.ProductCategory.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductCategory.Validations
{
    public class RenameProductCategoryCommandValidation : AbstractValidator<EditProductCategoryCommand>
    {
        public RenameProductCategoryCommandValidation(IProductCategoryApplication productCategoryApplication)
        {

            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
