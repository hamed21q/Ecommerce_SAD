using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ES.Domain.Entities.Products.Promotion
{
    public class Promotion : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public Promotion(string name, string description , float discountRate , DateTime startDate , DateTime endDate)
        { 
            Name = name;
            Description = description;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Edit(string name, string description, float discountRate, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Description = description;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;

        }
    }
}
