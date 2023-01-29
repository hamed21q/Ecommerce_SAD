using ES.Application.Contracts.Products.ProductCategory.DTOs;
using FluentValidation;
namespace ES.Application.Contracts.Products.ProductCategory.Validations
{
    public class CreateProductCategoryCommandValidation : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidation(IProductCategoryApplication productCategoryApplication)
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}