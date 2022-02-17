using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using System;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetBrands() => Ok(new { Results = _userManager.Users });

        [HttpPost]
        [Route("")]
        public IActionResult CreateUser(User user) => Ok(_userManager.CreateAsync(user).Result);

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id) => Ok(_userManager.FindByIdAsync(id.ToString()).Result);

        [HttpPut]
        [Route("")]
        public IActionResult EditUser(User user) => Ok(_userManager.UpdateAsync(user).Result);

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                return Ok(_userManager.DeleteAsync(_userManager.FindByIdAsync(id.ToString()).Result).Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
