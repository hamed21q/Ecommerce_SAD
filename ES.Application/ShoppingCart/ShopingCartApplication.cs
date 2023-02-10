using ES.Application.Contracts.ShoppingCard.ShoppingCard;
using ES.Application.Contracts.ShoppingCard.ShoppingCard.DTOs;
using ES.Application.Contracts.ShoppingCard.ShoppingCard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.ShoppingCart
{
    public class ShopingCartApplication : IShoppingCartApplication
    {
        public void Add(CreatShoppingCartCommand command)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Contracts.Products.Promotion.DTOs.EditShoppingCartCommand command)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCartViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ShoppingCartViewModel GetdBy(long id)
        {
            throw new NotImplementedException();
        }
    }
}
