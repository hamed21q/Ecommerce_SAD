namespace ES.Domain.Entities.ProductCategory
{
    public class ProductCategory : BaseDomain
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public long? ParentId { get; private set; }


        public virtual ProductCategory Parent { get; private set; }
        public virtual List<ProductCategory> Children { get; private set; } = new List<ProductCategory>();

        public ProductCategory(string title, long parent) : base()
        {
            Title = title;
            ParentId = parent;
            IsDeleted = false;
        }
        public ProductCategory()
        {

        }
        public void Rename(long parent, string title)
        {
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
