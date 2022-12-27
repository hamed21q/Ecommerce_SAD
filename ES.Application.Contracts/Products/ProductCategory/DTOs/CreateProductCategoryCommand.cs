namespace ES.Application.Contracts.Products.ProductCategory.DTOs
{
    public class CreateProductCategoryCommand
    {
        public string Title { get; set; }
        public long Parent { get; set; }
    }
}