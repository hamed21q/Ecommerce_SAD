

namespace ES.Domain.ProductCategory
{
    public class ProductCategory : BaseDomain
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public long ParentId { get; private set; }


        public ProductCategory Parent { get; private set; }
        public List<ProductCategory> Children { get; private set; } = new List<ProductCategory>();

        public ProductCategory(string title, long parent) : base()
        {
            Title = title;
            ParentId = parent;
            IsDeleted = false;
        }
        public ProductCategory()
        {

        }
        public void Edit(long parent, string title)
        {
            ParentId = parent;
            Title = title;
        }
    }
}
