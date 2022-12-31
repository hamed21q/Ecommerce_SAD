using ES.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.Entities.Products.Promotion
{
<<<<<<<< HEAD:CS.Domain/Entities/Products/Promotion/IPromotionService.cs
    public interface IPromotionService : IRepository<long, Promotion>
========
    public interface IProductPromotionService : IRepository<long, ProductPromotion>
>>>>>>>> 36f0a1049742c3b082c065cad9db9447c56f9bd4:CS.Domain/Entities/Products/Promotion/IProductPromotionService.cs
    {
    }
}
