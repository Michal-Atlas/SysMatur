using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SysMatur.Data.Objects
{
    public class Feed
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public bool Visible { get; set; }
        public ApiType ApiType { get; set; }

        [JsonIgnore] public User Owner { get; set; }
    }

    public enum ApiType
    {
        Atom
        // Reddit,
    }
}