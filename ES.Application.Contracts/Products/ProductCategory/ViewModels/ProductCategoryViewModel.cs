namespace ES.Application.Contracts.Products.ProductCategory.ViewModels
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public long? Parent { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; } = "";
        public int Grade { get; set; }
    }
}