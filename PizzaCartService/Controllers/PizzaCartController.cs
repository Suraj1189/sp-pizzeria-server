using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaCartService.Data;
using PizzaCartService.Dtos;
using PizzaCartService.Models;

namespace PizzaCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaCartController : ControllerBase
    {
        private readonly IPizzaCartRepo _repository;
        private readonly IMapper _mapper;

        public PizzaCartController(IPizzaCartRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        [HttpPost]
        public ActionResult<CartReadDto> AddToCart(CartCreateDto createCartDto)
        {
            Console.WriteLine("--> Adding item to the cart...");

            var cardModel = _mapper.Map<Cart>(createCartDto);
            _repository.CreateCart(cardModel);
            _repository.SaveChanges();

            var cartReadDto = _mapper.Map<CartReadDto>(cardModel);

            return Ok(cartReadDto);
        }
        [HttpGet]
        [Route("fetch")]
        public ActionResult<IEnumerable<CartReadDto>> GetCartItems(int customerId)
        {
            Console.WriteLine($"--> Get cart items for customer id {customerId}");

            var carts = _repository.GetCartsById(customerId);
            var cartItems = _mapper.Map<IEnumerable<CartReadDto>>(carts);
            MapCartItems(cartItems);
            return Ok(cartItems);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteFromCart(int cartId)
        {
            Console.WriteLine($"--> Delete cart item for cart id {cartId}");

            _repository.DeleteCartById(cartId);
            var result = _repository.SaveChanges();
            return Ok(result);
        }

        [HttpPost]
        [Route("remove")]
        public ActionResult<bool> RemoveAllItemsFromCart(CartReadDto cartReadDto)
        {
            Console.WriteLine($"--> Empty cart item for cart id");

            _repository.RemoveAllCartItems();
            var result = _repository.SaveChanges();
            return Ok(result);
        }

        private void MapCartItems(IEnumerable<CartReadDto> cartItems)
        {
            if (cartItems != null)
            {
                foreach (var cart in cartItems)
                {
                    if (cart.PizzaId > 0)
                        cart.PizzaDTO = PrepDb.allCatalogItems.FirstOrDefault(id => id.PizzaId == cart.PizzaId);
                    else if (cart.NonPizzaId > 0)
                        cart.NonPizzaDTO = PrepDb.allCatalogItems.FirstOrDefault(id => id.NonPizzaId == cart.NonPizzaId);

                }
            }
        }
    }
}