using System.Threading.Tasks;
using Api.Models;
using Data;
using Data.Objects;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unitOfWork, IUserService service)
        {
            _unitOfWork = unitOfWork;
            _userService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sessionKey = HttpContext.Request.Cookies["sessionKey"];
            if (sessionKey == null) return new ForbidResult();
            return new ObjectResult(new UserModel(await _unitOfWork.SessionTokens.GetUserFromSessionToken(sessionKey)));
        }

        [HttpPut]
        public async Task<IActionResult> CreateUser(UserModel user, string passwordHash, string passwordSalt)
        {
            return new ObjectResult(await _userService.CreateUser(user.ToUser(passwordHash, passwordSalt)));
        }

        [HttpGet]
        [Route("salt")]
        public async Task<IActionResult> GetSalt(string userName)
        {
            return new ObjectResult((await _userService.GetUserByUsername(userName)).PasswordSalt);
        }
    }
}