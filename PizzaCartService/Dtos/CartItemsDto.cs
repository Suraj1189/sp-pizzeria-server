using System;
using System.Collections.Generic;

namespace PizzaCartService.Dtos
{
    public class CartItemsDto 
    {
        public int PizzaId { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public bool Finished { get; set; }
        public int SessionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCustomize { get; set; }
        public int NonPizzaId { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
