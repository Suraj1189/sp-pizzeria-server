using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaOrderService.Dtos;

namespace PizzaOrderService.SyncDataServices.Http
{
    public interface IOrderDataClient
    {
        Task RemoveItemsFromCart(OrderReadDto orderReadDto);
    }
}