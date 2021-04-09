using System.ComponentModel.DataAnnotations;

namespace Data.Objects
{
    public class FeedRedditApi
    {
        [Key] public int Id { get; set; }
        public Feed Base { get; set; }
        public string BearerToken { get; set; }
    }
}