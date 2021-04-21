using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public string Get(string username, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}