namespace ES.Application.Contracts.Products.ProductCategory.ViewModels
{
    public class DetailedProductCategoryViewModel : ProductCategoryViewModel
    {
        public List<ProductCategoryViewModel> childCategories { get; set; }
    }
}