using ES.Application.Contracts.ProductCategory.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductCategory.Validations
{
    public class RenameProductCategoryCommandValidation : AbstractValidator<EditProductCategoryCommand>
    {
        private readonly IProductCategoryApplication productCategoryApplication;
        public RenameProductCategoryCommandValidation(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;

            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Id).Must(id => productCategoryApplication.IsValid(id)).WithMessage("requested id isnt even exist");
            RuleFor(x => x.Parent).Must(id => productCategoryApplication.IsValid(id)).WithMessage("parent category is invalid");
        }
    }
}
