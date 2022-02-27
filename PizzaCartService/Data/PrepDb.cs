using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PizzaCartService.SyncDataServices.Http;

namespace PizzaCartService.Data
{
    public static class PrepDb
    {
        public static List<dynamic> allCatalogItems = new List<dynamic>();
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var httpClient = serviceScope.ServiceProvider.GetService<IPizzaDataClient>();
                allCatalogItems.AddRange(httpClient.GetAllCatalogs().Result);
            }
        }
    }
}