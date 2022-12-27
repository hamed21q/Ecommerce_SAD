using ES.Application.Contracts.Products.Product.ViewModels;
using ES.Application.Contracts.Products.ProductConfiguration.ViewModel;

namespace ES.Application.Contracts.Products.ProductItem.ViewModels
{
    public class ProductItemViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ProductViewModel Product { get; set; }
        public List<ProductConfigurationViewModel> Configurations { get; set; }
    }
}
