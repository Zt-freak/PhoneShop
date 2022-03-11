using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoneShop.API.Helpers;
using PhoneShop.API.Models;
using PhoneShop.Models;
using System;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly IJwtMiddleware _jwtHelper;
        public LoginController(IConfiguration config, UserManager<User> userManager, IJwtMiddleware jwtHelper)
        {
            _config = config;
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        [AllowAnonymous]
        [Route("api/login")]
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            IActionResult response = Unauthorized();
            User currentUser = _userManager.FindByNameAsync(login.UserName).Result;
            if (
                _userManager.CheckPasswordAsync(
                    currentUser,
                    login.Password
                ).Result
            )
            {
                var tokenString = _jwtHelper.GenerateJWT(
                    currentUser
                );
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpPost]
        [Route("api/register")]
        public ActionResult Register([FromBody] LoginModel registration)
        {
            try
            {
                User newUser = new()
                {
                    UserName = registration.UserName,
                    Email = registration.Email,
                    Address = "test",
                    City = "test",
                    LastName = "test",
                    PhoneNumber = "123456789",
                    ZipCode = "1234 ab"
                };
                IdentityResult result = _userManager.CreateAsync(newUser, registration.Password).Result;
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
