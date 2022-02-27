namespace PizzaService.Dtos
{
    public class PizzaIngredientDTO 
    {
        public int PizzaIngredientId { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public bool Finished { get; set; }
        public int SessionId { get; set; }
    }
}
