using System.Threading.Tasks;
using Api.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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

        [HttpPut]
        public async Task<IActionResult> New(string username, string passwordHash)
        {
            var res = await _authenticator.CreateClaim(username, passwordHash);
            if (res == null) return new ForbidResult();
            Response.Cookies.Append("sessionKey", res);
            return new ObjectResult(res);
        }
    }
}