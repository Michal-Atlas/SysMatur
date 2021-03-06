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
            var returns = new List<FeedBaseModel>();
            foreach (var feed in feeds)
                switch (feed.ApiType)
                {
                    case ApiType.Atom:
                        returns.Add(new FeedBaseModel(feed));
                        break;
                }

            return new ObjectResult(returns);
        }

        [HttpPost]
        [Route("Rss")]
        public async Task<IActionResult> AddRssFeed(FeedBaseModel feed)
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
        [Route("Visibility")]
        public async Task<IActionResult> Update(int feedId, bool visibility)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            if (!await _feedService.CheckOwnership(user.Id, feedId)) return new ForbidResult();

            await _feedService.SetVisibility(feedId, visibility);
            return new OkResult();
        }

        [HttpPatch]
        [Route("Url")]
        public async Task<IActionResult> Update(int feedId, string url)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            if (!await _feedService.CheckOwnership(user.Id, feedId)) return new ForbidResult();

            await _feedService.ChangeUrl(feedId, url);
            return new OkResult();
        }
    }
}