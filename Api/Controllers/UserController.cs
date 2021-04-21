using System.Threading.Tasks;
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
        public async Task<IActionResult> Get(int userId)
        {
            return new ObjectResult(await _userService.GetUserById(userId));
        }

        [HttpPut]
        public async Task<IActionResult> CreateUser(int id)
        {
            return new ObjectResult(await _userService.CreateUser(new User()));
        }
    }
}