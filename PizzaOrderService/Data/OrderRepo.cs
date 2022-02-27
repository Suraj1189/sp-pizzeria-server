using System;
using System.Collections.Generic;
using System.Linq;
using PizzaOrderService.Dtos;
using PizzaOrderService.Models;

namespace PizzaOrderService.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Add(order);
        }
        public Order GetActiveOrder(int customerId)
        {
            return _context.Orders.FirstOrDefault(p => p.CustomerId == customerId && !p.IsDone);
        }

        public void UpdateOrderStatus(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            var cart = _context.Orders.Find(order.OrderId);
            _context.Orders.Remove(cart);
        }
        public void DeleteOrderById(int orderId)
        {
            var cart = _context.Orders.Find(orderId);
            _context.Orders.Remove(cart);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}