using System.Threading.Tasks;
using Api.Auth;
using Api.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork, IAuthenticator authenticator)
        {
            _unitOfWork = unitOfWork;
            _authenticator = authenticator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();
            return new ObjectResult(new UserModel(
                await _unitOfWork.SessionTokens.GetUserFromSessionToken(HttpContext.Request.Cookies["sessionKey"])));
        }

        [HttpPut]
        public async Task<IActionResult> CreateUser(UserModel user, string passwordHash, string passwordSalt)
        {
            var userObj = user.ToUser(passwordHash, passwordSalt);
            if (await _unitOfWork.Users.CheckExistsAsync(userObj)) return new ForbidResult();
            ;
            return new ObjectResult(await _unitOfWork.Users.CreateUserAsync(userObj));
        }

        [HttpGet]
        [Route("salt")]
        public async Task<IActionResult> GetSalt(string userName)
        {
            return new ObjectResult((await _unitOfWork.Users.GetUserByUsernameAsync(userName)).PasswordSalt);
        }
    }
}