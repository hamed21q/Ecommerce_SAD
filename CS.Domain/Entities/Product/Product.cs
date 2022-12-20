﻿
namespace ES.Domain.Entities.Product
{
    public class Product : BaseDomain
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public string Image { get; private set; }

        //Navigation
        public virtual ProductCategory.ProductCategory Category { get; private set; }
        protected Product() { }
        public Product(string name, string description, long categoryId, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Image = image;
        }
    }
}