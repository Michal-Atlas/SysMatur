using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Auth;
using Api.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using SimpleFeedReader;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedRssController : ControllerBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IUnitOfWork _unitOfWork;

        public FeedRssController(IUnitOfWork unitOfWork, IAuthenticator authenticator)
        {
            _unitOfWork = unitOfWork;
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
                    Body = item.Content
                });

            return new ObjectResult(output);
        }
    }
}