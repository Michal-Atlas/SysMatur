using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SysMatur.Api.Auth;

namespace SysMatur.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;

        public AuthController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        [HttpPost]
        public async Task<IActionResult> New(string username, string passwordHash)
        {
            var res = await _authenticator.CreateClaim(username, passwordHash);
            if (res == null) return new ForbidResult();
            Response.Cookies.Append("sessionKey", res);
            return new ObjectResult(res);
        }
    }
}