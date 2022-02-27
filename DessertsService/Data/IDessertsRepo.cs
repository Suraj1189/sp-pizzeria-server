using System.Collections.Generic;
using DessertsService.Models;

namespace DessertsService.Data
{
    public interface IDessertsRepo
    {
        bool SaveChanges();
        IEnumerable<Dessert> GetAllDesserts();
        Dessert GetDessertById(int id);
    }
}