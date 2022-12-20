using ES.Application.Contracts.Product.DTOs;
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
        private readonly IProductApplication productApplication;
        public CreateProductCommandValidation(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty().Must(categoryId => productApplication.IsValid(categoryId));
        }
    }
}
