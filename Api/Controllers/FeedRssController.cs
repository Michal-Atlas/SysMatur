using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Auth;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleFeedReader;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedRssController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;

        public FeedRssController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string url)
        {
            var user = await _authenticator.VerifyClaim(HttpContext.Request.Cookies["sessionKey"]);
            if (user == null) return new ForbidResult();

            var reader = new FeedReader();
            var items = reader.RetrieveFeed(url);
            var output = new List<Post>();

            foreach (var item in items)
                output.Add(new Post
                {
                    Title = item.Title,
                    Date = item.PublishDate,
                    Images = item.Images,
                    Summary = item.Summary,
                    Body = item.Content,
                    Anchor = item.Uri
                });

            return new ObjectResult(output);
        }
    }
}