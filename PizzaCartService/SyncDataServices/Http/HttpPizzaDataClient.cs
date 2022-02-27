using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PizzaCartService.Dtos;

namespace PizzaCartService.SyncDataServices.Http
{
    public class HttpPizzaDataClient : IPizzaDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpPizzaDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<dynamic>> GetAllCatalogs()
        {
            List<dynamic> allCatalogItems = new List<dynamic>();
            allCatalogItems.AddRange(await GetData<CartItemsDto>("http://localhost:5000/api/pizza"));
            allCatalogItems.AddRange(await GetData<CartItemsDto>("http://localhost:5005/api/beverages"));
            allCatalogItems.AddRange(await GetData<CartItemsDto>("http://localhost:5007/api/desserts"));
            allCatalogItems.AddRange(await GetData<CartItemsDto>("http://localhost:5003/api/sides"));
            allCatalogItems.AddRange(await GetData<CartItemsDto>("http://localhost:5009/api/custompizza"));

            return allCatalogItems;
        }
        private async Task<List<T>> GetData<T>(string url)
        {
            List<T> catItems = new List<T>();
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"--> Sync GET to {url} was OK!");

                    var data = await response.Content.ReadAsStringAsync();
                   
                    var catalogItems = JsonConvert.DeserializeObject<List<T>>(data);
                    if (catalogItems?.Count > 0)
                    {
                        catItems.AddRange(catalogItems);
                    }
                        
                }
                else
                {
                    Console.WriteLine($"--> Sync GET to {url} was NOT OK!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Error occured on http call {ex.Message}");
            }
            return catItems;
        }
    }
}