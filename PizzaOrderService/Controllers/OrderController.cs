using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderService.Data;
using PizzaOrderService.Dtos;
using PizzaOrderService.Models;
using PizzaOrderService.SyncDataServices.Http;

namespace PizzaOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _repository;
        private readonly IOrderDataClient _orderDataClient;

        public OrderController(IMapper mapper, IOrderRepo repository, IOrderDataClient orderDataClient)
        {
            _mapper = mapper;
            _repository = repository;
            _orderDataClient = orderDataClient;
        }

        [HttpPost]
        public ActionResult<OrderReadDto> PlaceOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            _repository.CreateOrder(order);
            _repository.SaveChanges();

            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }
        [HttpGet]
        public ActionResult<OrderReadDto> GetActiveOrder(int customerId)
        {
            var order = _repository.GetActiveOrder(customerId);
            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderReadDto);
        }
        [HttpPut]
        [Route("done")]
        public ActionResult<bool> UpdateOrderStatus(OrderReadDto orderReadDto)
        {
            var order = _mapper.Map<Order>(orderReadDto);
            _repository.UpdateOrderStatus(order);
            var result = _repository.SaveChanges();
            _orderDataClient.RemoveItemsFromCart(orderReadDto);
            return Ok(result);
        }
    }
}