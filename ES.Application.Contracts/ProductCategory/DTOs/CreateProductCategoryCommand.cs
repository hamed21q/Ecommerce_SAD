namespace ES.Application.Contracts.ProductCategory.DTOs
{
    public class CreateProductCategoryCommand
    {
        public string Title { get; set; }
        public long Parent { get; set; }
    }
}