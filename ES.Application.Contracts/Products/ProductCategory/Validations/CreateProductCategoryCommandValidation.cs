using ES.Application.Contracts.Products.ProductCategory.DTOs;
using FluentValidation;
namespace ES.Application.Contracts.Products.ProductCategory.Validations
{
    public class CreateProductCategoryCommandValidation : AbstractValidator<CreateProductCategoryCommand>
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public CreateProductCategoryCommandValidation(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Parent).Must(id => productCategoryApplication.IsValid(id)).WithMessage("invalid parent category");
        }
    }
}