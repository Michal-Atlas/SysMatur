using System.Collections.Generic;
using System.Linq;
using DatabaseModel;
using DatabaseModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedsController : ControllerBase
    {
        private readonly SysMaturDbContext dbcontext = new();

        [HttpGet]
        [Route("GetFeeds")]
        public IEnumerable<Feed> GetFeeds(string sub)
        {
            return dbcontext.Users.Where(x => x.Auth0Sub == sub).First().Feeds;
        }

        [HttpPost]
        [Route("Add")]
        public void Add(string address, string sub)
        {
            if (!dbcontext.Domains.Any(x => x.Address == address))
            {
                dbcontext.Domains.Add(new Domain {Address = address});
                dbcontext.SaveChanges();
            }

            dbcontext.Users.Where(x => x.Auth0Sub == sub).First().Feeds.Append(new Feed
                {Domain = dbcontext.Domains.Where(x => x.Address == address).First()});
            dbcontext.SaveChanges();
        }
    }
}