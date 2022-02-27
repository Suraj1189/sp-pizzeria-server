using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderService.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public DateTime PlaceDateTime { get; set; }
        public bool IsDone { get; set; }
    }
}