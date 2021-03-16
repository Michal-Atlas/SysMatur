using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.DbModel.Objects
{
    public class RedditApi
    {
        [Key] public int Id { get; set; }
        public Feed Base { get; set; }
    }
}