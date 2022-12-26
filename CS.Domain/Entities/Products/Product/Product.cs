namespace ES.Domain.Entities.Products.Product
{
    public class Product : BaseDomain
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public string Image { get; private set; }

        //Navigation
        public virtual ProductCategory.ProductCategory Category { get; private set; }
        public virtual List<ProductItem.ProductItem> ProductItems { get; private set; }
        protected Product() { }
        public Product(string name, string description, long categoryId, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Image = image;
        }
        public void Edit(string name, string description, long categoryId, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Image = image;
        }
    }
}