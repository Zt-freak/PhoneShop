using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using System;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetBrands() => Ok(new { Results = _brandService.GetAll() });

        [HttpPost]
        [Route("")]
        public IActionResult CreateBrand(Brand brand) => Ok(_brandService.Create(brand));

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBrand(int id) => Ok(_brandService.Get(id));

        [HttpPut]
        [Route("")]
        public IActionResult EditBrand(Brand brand) => Ok(_brandService.Update(brand));

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                _brandService.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
