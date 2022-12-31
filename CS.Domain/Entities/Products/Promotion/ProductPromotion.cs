using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ES.Domain.Entities.Products.Promotion
{
    public class ProductPromotion : BaseDomain
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double DiscountRate { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

<<<<<<<< HEAD:CS.Domain/Entities/Products/Promotion/Promotion.cs
        public Promotion(string name,
========
        public ProductPromotion(string name,
>>>>>>>> 36f0a1049742c3b082c065cad9db9447c56f9bd4:CS.Domain/Entities/Products/Promotion/ProductPromotion.cs
            string description,
            double discountRate,
            DateTime startDate,
            DateTime endDate) : base()
        {
            StartDate = startDate;
            EndDate = endDate;
            DiscountRate = DiscountRate;
            Name = name;
            Description = description;

        }
    }
}
