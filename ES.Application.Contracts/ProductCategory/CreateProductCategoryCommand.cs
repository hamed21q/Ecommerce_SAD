namespace ES.Application.Contracts.ProductCategory
{
    public class CreateProductCategoryCommand
    {
        public string Title { get; set; }
        public long Parent { get; set; }
    }
}