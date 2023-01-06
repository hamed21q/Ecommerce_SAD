using ES.Application.Contracts.ShoppingCart.ShoppingCartItem.DTOs;
using ES.Application.Contracts.ShoppingCart.ShoppingCartItem.ViewModels;
using ES.Application.Contracts.Users.Country.DTOs;
using ES.Application.Contracts.Users.Country.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ShoppingCart.ShoppingCartItem
{
    public interface IShoppingCartItemApplication
    {
        void Add(CreateShoppingCartItemCommand command);
        void Edit(EditShoppingCartItemCommand command);
        ShoppingCartItemViewModels GetdBy(long id);
        List<ShoppingCartItemViewModels> GetAll();
        void Delete(long id);
    }
}
