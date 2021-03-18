using System.ComponentModel.DataAnnotations;

namespace api.DbModel.Objects
{
    public class RedditApi
    {
        [Key] public int Id { get; set; }
        public Feed Base { get; set; }
        public string BearerToken { get; set; }
    }
}