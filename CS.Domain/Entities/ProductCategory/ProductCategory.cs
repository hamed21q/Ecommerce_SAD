namespace ES.Domain.Entities.ProductCategory
{
    public class ProductCategory : BaseDomain
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public long? ParentId { get; private set; }
        public int Grade { get; private set; }

        public virtual ProductCategory Parent { get; private set; }
        public virtual List<ProductCategory> ChildeCategories { get; private set; } = new List<ProductCategory>();
        public virtual List<Product.Product> Products { get; private set; }

        public ProductCategory(string title, long parent, int grade) : base()
        {
            Title = title;
            ParentId = parent;
            IsDeleted = false;
            Grade = grade;
        }
        public ProductCategory()
        {

        }
        public void Edit(long parent, string title, int grade)
        {
            Grade = grade;
            ParentId = parent;
            Title = title;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }


    }
}
