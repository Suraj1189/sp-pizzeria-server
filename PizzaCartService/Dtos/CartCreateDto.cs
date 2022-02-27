namespace PizzaCartService.Dtos
{
    public class CartCreateDto
    {
        public int PizzaId { get; set; }
        public int NonPizzaId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CustomerId { get; set; }
    }
}