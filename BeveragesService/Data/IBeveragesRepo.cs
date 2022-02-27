using System.Collections.Generic;
using BeveragesService.Models;

namespace BeveragesService.Data
{
    public interface IBeveragesRepo
    {
        bool SaveChanges();
        IEnumerable<Beverage> GetAllBeverages();
        Beverage GetBeverageById(int id);
    }
}