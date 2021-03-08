using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseModel;
using DatabaseModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SysMaturDbContext dbcontext = new SysMaturDbContext();

        [HttpGet]
        [Route("All")]
        public IEnumerable<User> GetAll()
        {
            return dbcontext.Users;
        }

        [HttpGet]
        [Route("Total")]
        public int Get()
        {
            return dbcontext.Users.Count();
        }

        [HttpGet]
        public User Get(int id)
        {
            return dbcontext.Users.Find(id);
        }

        [HttpPost]
        [Route("CookieTokens")]
        public void AddCookieToken(int userId, string address, string token)
        {
            dbcontext.Users.Find(userId).CookieTokens.Add(new CookieToken
                {Domain = new Domain {Address = address}, Token = token});
            dbcontext.SaveChanges();
        }

        [HttpGet]
        [Route("CookieTokens")]
        public IEnumerable<CookieToken> GetCookieTokens(int userId)
        {
            return dbcontext.Users.Include(x=>x.CookieTokens).FirstOrDefault(x=>x.Id==userId)?.CookieTokens;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            dbcontext.Users.Remove(dbcontext.Users.Find(id));
            dbcontext.SaveChanges();
            return 200;
        }

        [HttpPost]
        [Route("Create")]
        public void Create(string name)
        {
            dbcontext.Users.Add(new User {DisplayName = name});
            dbcontext.SaveChanges();
        }
    }
}