using System;

namespace CustomPizzaService.Dtos
{
    public class IngredientReadDto
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
    }
}