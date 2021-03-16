using System.ComponentModel.DataAnnotations;

namespace api.DbModel.Objects
{
    public class Feed
    {
        [Key] public int Id { get; set; }
        public string Url { get; set; }
        
        public bool Visible { get; set; }
        public string BearerToken { get; set; }
        public ApiType ApiType { get; set; }
    }

    public enum ApiType
    {
        Reddit,
    }
}