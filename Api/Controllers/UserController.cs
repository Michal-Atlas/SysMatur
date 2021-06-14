using System;
using System.Threading.Tasks;
using SysMatur.Data.Services;
using Microsoft.AspNetCore.Mvc;
using SysMatur.Api.Auth;
using SysMatur.Api.Models;

namespace SysMatur.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IAuthenticator authenticator)
        {
            _userService = userService;
            _authenticator = authenticator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();
            return new ObjectResult(new UserModel(
                await _userService.GetUserFromSessionToken(HttpContext.Request.Cookies["sessionKey"])));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user, string passwordHash, string passwordSalt)
        {
            var userObj = user.ToUser(passwordHash, passwordSalt);
            if (await _userService.CheckExistsAsync(userObj)) return new ConflictResult();
            return new ObjectResult(await _userService.CreateUserAsync(userObj));
        }

        [HttpGet]
        [Route("salt")]
        public async Task<IActionResult> GetSalt(string userName)
        {
            return new ObjectResult((await _userService.GetUserByUsernameAsync(userName)).PasswordSalt);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeUser(UserModel newState)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();
            var userObj = newState.ToUser("", "");
            if (await _userService.CheckExistsAsync(userObj)) return new ForbidResult();
            await _userService.ChangeUser(user, userObj);
            return new OkResult();
        }
    }
}