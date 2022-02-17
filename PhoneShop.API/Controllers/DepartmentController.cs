using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using PhoneShop.Models.Interfaces.Services;
using System;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetDepatments() => Ok(new { Results = _departmentService.GetAll() });

        [HttpPost]
        [Route("")]
        public IActionResult CreateDepartment(Department department) => Ok(_departmentService.Create(department));

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDepartment(int id) => Ok(_departmentService.Get(id));

        [HttpPut]
        [Route("")]
        public IActionResult EditDepartment(Department department) => Ok(_departmentService.Update(department));

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                _departmentService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
