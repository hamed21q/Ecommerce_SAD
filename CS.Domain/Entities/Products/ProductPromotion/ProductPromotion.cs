namespace ES.Domain.Entities.Products.ProductPromotion
{
    public class ProductPromotion : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public ProductPromotion(string name, string description , float discountRate , DateTime startDate , DateTime endDate)
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
