namespace ES.Application.Contracts.ProductCategory.ViewModels
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public string? Parent { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; } = "";
    }
}
