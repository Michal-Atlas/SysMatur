using SysMatur.Data.Objects;

namespace SysMatur.Api.Models
{
    public class FeedBaseModel
    {
        public FeedBaseModel(Feed feed)
        {
            Id = feed.Id;
            Name = feed.Name;
            Url = feed.Url;
            Visible = feed.Visible;
            ApiType = feed.ApiType;
        }

        public FeedBaseModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Visible { get; set; }
        public ApiType ApiType { get; set; }

        public Feed ToFeed(User owner)
        {
            return new()
            {
                Id = Id,
                Name = Name,
                Url = Url,
                Visible = Visible,
                ApiType = ApiType,
                Owner = owner
            };
        }
    }
}