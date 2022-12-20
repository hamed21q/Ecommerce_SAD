using ES.Application.Contracts.ProductCategory;
using ES.Application;
using ES.Domain;
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//product category
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

//product
builder.Services.AddTransient<IProductApplication, ProductApplication>();
builder.Services.AddTransient<IProductService, ProductService>();

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
