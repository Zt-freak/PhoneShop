using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PhoneShop.Models;

namespace PhoneShop.API.Helpers
{
    public interface IJwtMiddleware
    {
        //void Invoke(HttpContext context, IConfiguration config);
        string GenerateJWT(User inputUser);
    }
}
