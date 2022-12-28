﻿using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.ViewModels;

namespace ES.Application.Contracts.Products.Product
{
    public interface IProductApplication
    {
        void Add(CreateProductCommand command);
        bool IsValid(long id);
        void Edit(EditProductCommand command);
        ProductViewModel GetBy(long id);
        List<ProductViewModel> GetByCategory(long id);
        void Delete(long id);
        ProductViewModel Convert(Domain.Entities.Products.Product.Product product);
        List<ProductViewModel> GetAll();
    }
}