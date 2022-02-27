using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaService.Models
{
    public class Pizza
    {
        [Key]
        [Required]
        public int PizzaId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Price { get; set; }
        public bool Finished { get; set; }
        public int SessionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //public List<int> IngredientIds { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsCustomize { get; set; }
    }
}