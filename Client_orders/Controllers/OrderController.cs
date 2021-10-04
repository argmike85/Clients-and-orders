using Client_orders.Abstraction;
using Client_orders.Abstraction.OrderModels;
using Client_orders.DATA;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository order)
        {
            _orderRepository = order;
        }
        [HttpGet]
        public List<Order> GetOrdersAsync()
        {
            return _orderRepository.GetOrders.ToList();
        }

        [HttpPost]
        public async void CreateOrderAsync([FromBody] CreateOrderModel model)
        {
            await _orderRepository.CreateOrder(model);
        }

        [HttpPut]
        public async void UpdateOrderAsync([FromBody] UpdateOrderModel model)
        {
            await _orderRepository.UpdateOrder(model);
        }
        [HttpDelete]
        public async void DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrder(id);
        }


    }
}
