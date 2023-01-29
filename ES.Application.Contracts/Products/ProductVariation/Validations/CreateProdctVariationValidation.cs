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

        public CreateProdctVariationValidation(IProductCategoryApplication productVariationApplication)
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
