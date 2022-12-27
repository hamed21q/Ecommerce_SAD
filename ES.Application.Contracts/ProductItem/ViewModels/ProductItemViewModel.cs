using ES.Application.Contracts.Product.ViewModels;
using ES.Application.Contracts.ProductConfiguration.ViewModel;

namespace ES.Application.Contracts.ProductItem.ViewModels
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
