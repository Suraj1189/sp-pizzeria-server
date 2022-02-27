using System;

namespace PizzaOrderService.Dtos
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public DateTime PlaceDateTime { get; set; }
        public bool IsDone { get; set; }
    }
}