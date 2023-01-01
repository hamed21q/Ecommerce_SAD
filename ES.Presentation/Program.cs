using ES.Infructructure.EfCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ES.Domain.DomainService;
using ES.Infructructure.EfCore.Base;
using ES.Domain.Entities.Products.Product;
using ES.Domain.Entities.Products.ProductVariationOption;
using ES.Domain.Entities.Products.ProductVariation;
using ES.Domain.Entities.Products.ProductCategory;
using ES.Domain.Entities.Products.ProductConfiguration;
using ES.Domain.Entities.Products.ProductItem;
using ES.Infructructure.EfCore.Services.Products;
using ES.Application.Contracts.Products.ProductVariationOption.DTOs;
using ES.Application.Contracts.Products.ProductVariationOption.Validations;
using ES.Application.Contracts.Products.ProductVariationOption;
using ES.Application.Contracts.Products.ProductVariation.DTOs;
using ES.Application.Contracts.Products.ProductVariation.Validations;
using ES.Application.Contracts.Products.ProductVariation;
using ES.Application.Contracts.Products.ProductCategory.DTOs;
using ES.Application.Contracts.Products.ProductCategory.Validations;
using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.Validations;
using ES.Application.Contracts.Products.Product;
using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Application.Contracts.Products.ProductItem.Validations;
using ES.Application.Contracts.Products.ProductItem;
using ES.Application.Contracts.Products.ProductConfiguration;
using ES.Application.Products;
using ES.Infructructure.EfCore.Services.Products.Products;
using ES.Application.Contracts.Users.Role;
using ES.Application.Users;
using ES.Domain.Entities.Users.Role;
using ES.Infructructure.EfCore.Services.Users;
using ES.Application.Contracts.Users.Country;
using ES.Domain.Entities.Users.Country;
using ES.Application.Contracts.Users.UserAddress;
using ES.Domain.Entities.Users.UserAddress;
using ES.Application.Contracts.Users.User;
using ES.Domain.Entities.Users.User;

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
builder.Services.AddTransient<IValidator<CreateProductItemCommand>, CreateProductItemValidation>();




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

//product item
builder.Services.AddTransient<IProductItemApplication, ProductItemApplication>();
builder.Services.AddTransient<IProductItemService, ProductItemService>();

//product Configuration
builder.Services.AddTransient<IProductConfigurationApplication, ProductConfigurationApplication>();
builder.Services.AddTransient<IProductConfigurationService, ProductConfigurationService>();

//user role
builder.Services.AddTransient<IUserRoleApplication, UserRoleApplication>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();

//country
builder.Services.AddTransient<ICountryApplication, CountryApplication>();
builder.Services.AddTransient<ICountryService, CountryService>();

//user Address
builder.Services.AddTransient<IUserAddressApplication, UserAddressApplication>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();

//user
builder.Services.AddTransient<IUserApplication, UserApplication>();
builder.Services.AddTransient<IUserService, UserService>();


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
