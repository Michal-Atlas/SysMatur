using Data.Objects;

namespace Api.Models
{
    public class FeedRssModel
    {
        public FeedRssModel(Feed feed)
        {
            Url = feed.Url;
            Visible = feed.Visible;
            ApiType = feed.ApiType;
        }

        public FeedRssModel()
        {
        }

        public string Url { get; set; }
        public bool Visible { get; set; }
        public ApiType ApiType { get; set; }

        public Feed ToFeed()
        {
            return new()
            {
                Url = Url,
                Visible = Visible,
                ApiType = ApiType
            };
        }
    }
}