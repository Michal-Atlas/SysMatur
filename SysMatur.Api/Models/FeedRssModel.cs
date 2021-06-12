using SysMatur.Data.Objects;

namespace SysMatur.Api.Models
{
    public class FeedRssModel
    {
        public FeedRssModel(Feed feed)
        {
            Id = feed.Id;
            Url = feed.Url;
            Visible = feed.Visible;
            ApiType = feed.ApiType;
        }

        public FeedRssModel()
        {
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public bool Visible { get; set; }
        public ApiType ApiType { get; set; }

        public Feed ToFeed(User owner)
        {
            return new()
            {
                Id = Id,
                Url = Url,
                Visible = Visible,
                ApiType = ApiType,
                Owner = owner
            };
        }
    }
}