using System.Collections.Generic;
using PizzaCartService.Models;

namespace PizzaCartService.Data
{
    public interface IPizzaCartRepo
    {
        bool SaveChanges();
        IEnumerable<Cart> GetAllCarts();
        IEnumerable<Cart> GetCartsById(int id);
        void CreateCart(Cart cart);
        void DeleteCartById(int cartId);
        void RemoveAllCartItems();
    }
}