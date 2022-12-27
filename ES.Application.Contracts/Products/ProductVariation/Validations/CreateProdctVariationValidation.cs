using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Contracts.Products.ProductVariation.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Products.ProductVariation.Validations
{
    public class CreateProdctVariationValidation : AbstractValidator<CreateProductVariationCommand>
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public CreateProdctVariationValidation(IProductCategoryApplication productVariationApplication)
        {
            productCategoryApplication = productVariationApplication;
            RuleFor(x => x.CategoryId).Must(id => productCategoryApplication.IsValid(id)).WithMessage("Invalid Product Categoy");
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
