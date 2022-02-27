using System;

namespace DessertsService.Dtos
{
    public class DessertReadDto
    {
        public int NonPizzaId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}