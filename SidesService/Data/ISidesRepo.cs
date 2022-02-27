using System.Collections.Generic;
using SidesService.Models;

namespace SidesService.Data
{
    public interface ISidesRepo
    {
        bool SaveChanges();
        IEnumerable<Side> GetAllSides();
        Side GetSideById(int id);
    }
}