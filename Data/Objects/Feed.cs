using System.ComponentModel.DataAnnotations;

namespace Data.Objects
{
    public class Feed
    {
        [Key] public int Id { get; set; }
        public string Url { get; set; }

        public bool Visible { get; set; }
        public ApiType ApiType { get; set; }
        public User Owner { get; set; }
    }

    public enum ApiType
    {
        Reddit,
        Atom
    }
}