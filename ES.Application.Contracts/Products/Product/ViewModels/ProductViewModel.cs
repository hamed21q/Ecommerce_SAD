using ES.Application.Contracts.Products.ProductItem.ViewModels;

namespace ES.Application.Contracts.Products.Product.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public double MinimumPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}
