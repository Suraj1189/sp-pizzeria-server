using System;
using System.ComponentModel.DataAnnotations;

namespace SidesService.Models
{
    public class Side
    {
        [Key]
        [Required]
        public int NonPizzaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}