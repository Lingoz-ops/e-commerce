using Ecommerce.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            var result = _order.CreateOrder(order);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Order> UpdateOrderById(string orderId, Order updatedOrder)
        {
            var result = _order.UpdateOrderById(orderId, updatedOrder);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<Order> GetOrder(string orderId)
        {
            var result = _order.GetOrderById(orderId);
            return Ok(result);

        }
    }
}
