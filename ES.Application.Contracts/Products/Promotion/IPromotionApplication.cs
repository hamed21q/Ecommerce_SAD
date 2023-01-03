﻿using ES.Application.Contracts.Products.Promotion.DTOs;
using ES.Application.Contracts.Products.Promotion.ViewModels;

namespace ES.Application.Contracts.Products.Promotion
{
    public interface IPromotionApplication
    {
        void Add(CreateShoppingCartCommand command);
        void Edit(EditShoppingCartCommand command);
        ShoppingCartViewmodels GetdBy(long id);
        List<ShoppingCartViewmodels> GetAll();
        void Delete(long id);
    }
}
