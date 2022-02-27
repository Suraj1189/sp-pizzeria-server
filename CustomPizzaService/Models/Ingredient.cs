using System;
using System.ComponentModel.DataAnnotations;

namespace CustomPizzaService.Models
{
    public class Ingredient
    {
        [Key]
        [Required]
        public int IngredientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}