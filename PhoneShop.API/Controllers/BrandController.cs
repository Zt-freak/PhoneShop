using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;

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
    }
}
