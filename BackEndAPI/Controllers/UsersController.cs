using System.Collections.Generic;
using System.Linq;
using DatabaseModel;
using DatabaseModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SysMaturDbContext dbcontext = new();

        [HttpGet]
        [Route("All")]
        public IEnumerable<User> GetAll()
        {
            return dbcontext.Users;
        }

        [HttpGet]
        [Route("Debug")]
        public int Get()
        {
            return dbcontext.Users.Count();
        }

        [HttpGet]
        public User Get(int id)
        {
            return dbcontext.Users.Find(id);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            dbcontext.Users.Remove(dbcontext.Users.Find(id));
            dbcontext.SaveChanges();
            return 200;
        }
    }
}