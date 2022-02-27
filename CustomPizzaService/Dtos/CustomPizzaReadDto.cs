﻿using System.Collections.Generic;

namespace CustomPizzaService.Dtos
{
    public class CustomPizzaReadDto 
    {
        public int PizzaId { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public bool Finished { get; set; }
        public int SessionId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsCustomize { get; set; }
    }
}
