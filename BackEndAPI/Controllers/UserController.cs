using System.Linq;
using DatabaseModel;
using DatabaseModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly SysMaturDbContext dbcontext = new();

        [HttpGet]
        [Route("Debug")]
        public int Get()
        {
            return dbcontext.Users.Count();
        }

        /// <summary>
        ///     User by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public User Get(int id)
        {
            return dbcontext.Users.Find(id);
        }

        /// <summary>
        ///     Add User
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPut]
        public int Put(string userName)
        {
            dbcontext.Users.Add(new User {UserName = userName});
            return dbcontext.SaveChanges();
        }
    }
}