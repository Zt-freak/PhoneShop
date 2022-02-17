using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using System;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IProductService _phoneService;
        public PhoneController(IProductService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetPhones() => Ok(new { Results = _phoneService.GetAll() });

        [HttpPost]
        [Route("")]
        public IActionResult CreatePhone(Product phone) => Ok(_phoneService.Create(phone));

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPhone(int id) => Ok(_phoneService.Get(id));

        [HttpPut]
        [Route("")]
        public IActionResult EditPhone(Product phone) => Ok(_phoneService.Update(phone));

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePhone(int id)
        {
            try
            {
                _phoneService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
