namespace ES.Application.Contracts.Products.Promotion.DTOs
{
    public class EditShoppingCartCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PromotionId { get;}

    }
}
