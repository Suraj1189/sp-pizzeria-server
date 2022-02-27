using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderService.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public int TotalAmount { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime DeliveryDateTime { get; set; }
        [Required]
        public DateTime PlaceDateTime { get; set; }
        [Required]
        public bool IsDone { get; set; }
    }
}