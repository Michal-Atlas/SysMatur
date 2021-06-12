using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SysMatur.Data.Objects;
using SysMatur.Data.Services;
using Microsoft.AspNetCore.Mvc;
using SysMatur.Api.Auth;
using SysMatur.Api.Models;

namespace SysMatur.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IFeedService _feedService;

        public FeedController(IFeedService feedService, IAuthenticator authenticator)
        {
            _feedService = feedService;
            _authenticator = authenticator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            var feeds = await _feedService.GetByUsernameAsync(user.Username);
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
            return new ObjectResult(await _feedService.CreateAsync(feed.ToFeed(user)));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRssFeed(int feedId)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();
            if (!await _feedService.CheckOwnership(user.Id, feedId)) return new ForbidResult();
            await _feedService.DeleteAsync(feedId);
            return new OkResult();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int feedId, bool? visibility, string? url)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            if (!await _feedService.CheckOwnership(user.Id, feedId)) return new ForbidResult();

            if (visibility.HasValue) await _feedService.SetVisibility(feedId, visibility.Value);
            if (url != null) await _feedService.ChangeUrl(feedId, url);
            return new OkResult();
        }
    }
}