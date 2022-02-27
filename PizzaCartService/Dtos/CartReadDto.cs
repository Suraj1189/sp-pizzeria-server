namespace PizzaCartService.Dtos
{
    public class CartReadDto
    {
        public int CartId { get; set; }
        public int PizzaId { get; set; }
        public int NonPizzaId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CustomerId { get; set; }
        public CartItemsDto PizzaDTO { get; set; }
        public CartItemsDto NonPizzaDTO { get; set; }
    }
}