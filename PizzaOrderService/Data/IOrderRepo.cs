using System.Collections.Generic;
using PizzaOrderService.Models;

namespace PizzaOrderService.Data
{
    public interface IOrderRepo
    {
        bool SaveChanges();
        Order GetActiveOrder(int id);
        void CreateOrder(Order cart);
        void DeleteOrderById(int orderId);
        void UpdateOrderStatus(Order order);
    }
}