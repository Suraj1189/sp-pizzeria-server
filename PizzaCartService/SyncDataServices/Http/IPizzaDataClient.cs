using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaCartService.SyncDataServices.Http
{
    public interface IPizzaDataClient
    {
        Task<List<dynamic>> GetAllCatalogs();
    }
}