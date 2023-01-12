using ES.Application.Contracts.Products.ProductItem.ViewModels;

namespace ES.Application.Contracts.Products.Product.ViewModels
{
    public class DetailedProductViewModel : ProductViewModel
    {
        public List<ProductItemViewModel> items { get; set; }
    }
}
