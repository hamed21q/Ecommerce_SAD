using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Contracts.Products.ProductVariation.DTOs;
using FluentValidation;
namespace ES.Application.Contracts.Products.ProductVariation.Validations
{
    public class EditProductVariationValidation : AbstractValidator<EditProductVariationCommand>
    {
        public EditProductVariationValidation(IProductVariationApplication productVariationApplication, IProductCategoryApplication productCategoryApplication)
        {
     
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}