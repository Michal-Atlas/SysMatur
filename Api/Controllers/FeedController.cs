using System;
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
            if (!Enum.IsDefined(typeof(ApiType), feed.ApiType)) return new ConflictResult();
            return new ObjectResult(await _unitOfWork.Feeds.CreateFeedAsync(feed.ToFeed(user)));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRssFeed(int feedId)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();
            if (!await _unitOfWork.Feeds.CheckOwnership(user.Id, feedId)) return new ForbidResult();
            await _unitOfWork.Feeds.DeleteFeedAsync(feedId);
            return new OkResult();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int feedId, bool? visibility, string? url)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            if (!await _unitOfWork.Feeds.CheckOwnership(user.Id, feedId)) return new ForbidResult();

            if (visibility.HasValue) await _unitOfWork.Feeds.SetVisibility(feedId, visibility.Value);
            if (url != null) await _unitOfWork.Feeds.ChangeUrl(feedId, url);
            return new OkResult();
        }
    }
}