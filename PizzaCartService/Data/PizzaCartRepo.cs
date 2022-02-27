using System;
using System.Collections.Generic;
using System.Linq;
using PizzaCartService.Dtos;
using PizzaCartService.Models;

namespace PizzaCartService.Data
{
    public class PizzaCartRepo : IPizzaCartRepo
    {
        private readonly AppDbContext _context;

        public PizzaCartRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCart(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            _context.Carts.Add(cart);
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _context.Carts.ToList();
        }

        public IEnumerable<Cart> GetCartsById(int id)
        {
            return _context.Carts.Where(p => p.CustomerId == id)?.ToList();
        }

        public void DeleteCartById(int cartId)
        {
            var cart = _context.Carts.Find(cartId);
            _context.Carts.Remove(cart);
        }

        public void RemoveAllCartItems()
        {
            foreach (var cart in _context.Carts)
            {
                _context.Carts.Remove(cart);
            }
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}