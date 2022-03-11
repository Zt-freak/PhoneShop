using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using System;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetOrders() => Ok(new { Results = _orderService.GetAll() });

        [HttpPost]
        [Route("")]
        public IActionResult CreateOrder(Order order) => Ok(_orderService.Create(order));

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOrder(int id) => Ok(_orderService.Get(id));

        [HttpPut]
        [Route("")]
        public IActionResult EditOrder(Order order) => Ok(_orderService.Update(order));

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _orderService.Delete(id, 0);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
