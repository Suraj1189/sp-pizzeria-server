using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PizzaOrderService.Dtos;

namespace PizzaOrderService.SyncDataServices.Http
{
    public class HttpOrderDataClient : IOrderDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpOrderDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task RemoveItemsFromCart(OrderReadDto orderReadDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(orderReadDto),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5011/api/pizzacart/remove", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CartService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CartService was NOT OK!");
            }
        }
    }
}