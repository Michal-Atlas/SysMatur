using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Auth;
using Api.Models;
using Data;
using Data.Objects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IUnitOfWork _unitOfWork;

        public FeedController(IUnitOfWork unitOfWork, IAuthenticator authenticator)
        {
            _unitOfWork = unitOfWork;
            _authenticator = authenticator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            var feeds = await _unitOfWork.Feeds.GetFeedsByUsernameAsync(user.Username);
            var returns = new List<object>();
            foreach (var feed in feeds)
                switch (feed.ApiType)
                {
                    case ApiType.Atom:
                        returns.Add(new FeedRssModel(feed));
                        break;
                }

            return new ObjectResult(returns);
        }

        [HttpPut]
        [Route("rss")]
        public async Task<IActionResult> AddRssFeed(FeedRssModel feed)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            _unitOfWork.Feeds.AddAsync(feed.ToFeed());

            return new OkResult();
        }
    }
}