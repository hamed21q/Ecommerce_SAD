namespace ES.Application.Contracts.Products.Promotion.DTOs
{
    public class CreateShoppingCartCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductPromotion { get; set; }
    }
}
