using System.ComponentModel.DataAnnotations;

namespace PizzaCartService.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int CartId { get; set; }
        public int PizzaId { get; set; }
        public int NonPizzaId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}