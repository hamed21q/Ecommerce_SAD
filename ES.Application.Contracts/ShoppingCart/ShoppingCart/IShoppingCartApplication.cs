using ES.Application.Contracts.Products.Promotion.DTOs;
using ES.Application.Contracts.Products.Promotion.ViewModels;
using ES.Application.Contracts.ShoppingCard.ShoppingCard.DTOs;
using ES.Application.Contracts.ShoppingCard.ShoppingCard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Contracts.ShoppingCard.ShoppingCard
{
    public interface IShoppingCartApplication
    {
        void Add(CreatShoppingCartCommand command);
        void Edit(EditShoppingCartCommand command);
        ShoppingCartViewModel GetdBy(long id);
        List<ShoppingCartViewModel> GetAll();
        void Delete(long id);
    }
}