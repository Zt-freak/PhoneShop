using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PhoneShop.API.Helpers
{
    public class JwtMiddleware : IJwtMiddleware
    {
        //private readonly RequestDelegate _delegate;
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public JwtMiddleware(/*RequestDelegate theDelegate,*/ IConfiguration config, UserManager<User> userManager)
        {
            //_delegate = theDelegate;
            _config = config;
            _userManager = userManager;
        }

        /*public void Invoke(HttpContext context, IConfiguration config)
        {
            string bearerToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (bearerToken != null)
                AttachAccountToContext(context, bearerToken);

            _delegate(context);
        }

        private void AttachAccountToContext(HttpContext context, string bearerToken)
        {
            try
            {
                JwtSecurityTokenHandler jwtHandler = new();
                byte[] key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

                jwtHandler.ValidateToken(
                    bearerToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                        ValidateIssuer = true,
                        ValidIssuer = _config["Jwt:Issuer"],
                    },
                    out SecurityToken validatedToken
                );

                JwtSecurityToken jwt = (JwtSecurityToken)validatedToken;
                string userId = jwt.Claims.First(x => x.Type == "nameid")?.Value;
                string roles = jwt.Claims.First(x => x.Type == "role")?.Value;
                string memberships = jwt.Claims.First(x => x.Type == "memberships")?.Value;

                if (context.User == null)
                    return;

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userId),
                        new Claim(ClaimTypes.Role, roles)
                    };

                var appIdentity = new ClaimsIdentity(claims);
                context.User.AddIdentity(appIdentity);

            }
            catch (Exception)
            {

            }
        }*/

        public string GenerateJWT(User inputUser)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            User user = _userManager.FindByIdAsync(inputUser.Id.ToString()).Result;
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role, string.Join( ",", roles.ToArray() ))
            };

            JwtSecurityToken token = new (_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
