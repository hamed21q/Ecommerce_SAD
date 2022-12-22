using ES.Application.Contracts.ProductCategory;
using ES.Application;
using ES.Infructructure.EfCore.Services;
using ES.Infructructure.EfCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using ES.Application.Contracts.ProductCategory.Validations;
using ES.Application.Contracts.ProductCategory.DTOs;
using ES.Domain.Entities.ProductCategory;
using ES.Application.Contracts.Product.Validations;
using ES.Application.Contracts.Product.DTOs;
using ES.Application.Contracts.Product;
using Microsoft.EntityFrameworkCore;
using ES.Domain.Entities.Product;
using ES.Domain.DomainService;
using ES.Infructructure.EfCore.Base;
using ES.Application.Contracts.ProductVariation;
using ES.Domain.Entities.ProductVariation;
using ES.Application.Contracts.ProductVariation.DTOs;
using ES.Application.Contracts.ProductVariation.Validations;
using ES.Application.Contracts.ProductVariationOption.DTOs;
using ES.Application.Contracts.ProductVariationOption.Validations;
using ES.Application.Contracts.ProductVariationOption;
using ES.Domain.Entities.ProductVariationOption;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(x =>
    {
        x.ImplicitlyValidateChildProperties = true;
    });

//validations
builder.Services.AddTransient<IValidator<CreateProductCategoryCommand>, CreateProductCategoryCommandValidation>();
builder.Services.AddTransient<IValidator<EditProductCategoryCommand>, RenameProductCategoryCommandValidation>();
builder.Services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidation>();
builder.Services.AddTransient<IValidator<CreateProductVariationCommand>, CreateProdctVariationValidation>();
builder.Services.AddTransient<IValidator<EditProductVariationCommand>, EditProductVariationValidation>();
builder.Services.AddTransient<IValidator<EditProductVariationOptionCommand>, EditProductVariatioOptionValidation>();
builder.Services.AddTransient<IValidator<CreateProductVariationOptionCommand>, CreateProductVariatioOptionValidation>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//product category
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

//product
builder.Services.AddTransient<IProductApplication, ProductApplication>();
builder.Services.AddTransient<IProductService, ProductService>();

//product variation
builder.Services.AddTransient<IProductVariationApplication, ProductVariationApplication>();
builder.Services.AddTransient<IProductVariationService, ProductVariationService>();

//product variation option
builder.Services.AddTransient<IProductVariationOptionApplication, ProductVariationOptionApplication>();
builder.Services.AddTransient<IProductVariationOptionService, ProductVariationOptionService>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<EcommerceContext>(option => option
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
