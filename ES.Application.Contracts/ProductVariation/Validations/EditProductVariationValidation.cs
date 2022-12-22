using ES.Application.Contracts.ProductCategory;
using ES.Application.Contracts.ProductVariation.DTOs;
using FluentValidation;
namespace ES.Application.Contracts.ProductVariation.Validations
{
    public class EditProductVariationValidation : AbstractValidator<EditProductVariationCommand>
    {
        private readonly IProductVariationApplication productVariationApplication;
        private readonly IProductCategoryApplication productCategoryApplication;

        public EditProductVariationValidation(IProductVariationApplication productVariationApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication= productCategoryApplication;
            this.productVariationApplication = productVariationApplication;
            RuleFor(x => x.Id).Must(x => productVariationApplication.IsValid(x));
            RuleFor(x => x.CategoryId).Must(x => productCategoryApplication.IsValid(x));
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}