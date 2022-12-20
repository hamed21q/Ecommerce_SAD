using ES.Application.Contracts.Product.DTOs;
using ES.Application.Contracts.ProductCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.Product.Validations
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductCategoryApplication productCategoryApplication;
        public CreateProductCommandValidation(IProductCategoryApplication productApplication)
        {
            this.productCategoryApplication = productApplication;
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.CategoryId).Must(id => productApplication.IsValid(id));
        }
    }
}
