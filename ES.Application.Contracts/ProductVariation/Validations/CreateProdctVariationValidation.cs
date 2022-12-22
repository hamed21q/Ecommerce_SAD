using ES.Application.Contracts.ProductCategory;
using ES.Application.Contracts.ProductVariation.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ProductVariation.Validations
{
    public class CreateProdctVariationValidation : AbstractValidator<CreateProductVariationCommand>
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public CreateProdctVariationValidation(IProductCategoryApplication productVariationApplication)
        {
            this.productCategoryApplication = productVariationApplication;
            RuleFor(x => x.CategoryId).Must(id => productCategoryApplication.IsValid(id)).WithMessage("Invalid Product Categoy");
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
