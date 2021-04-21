using System.ComponentModel.DataAnnotations;

namespace Data.Objects
{
    public class FeedRss
    {
        [Key] public int Id { get; set; }
        public Feed Base { get; set; }
    }
}