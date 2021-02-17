using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class Feed
    {
        [Key] public int Id { get; set; }

        public Type Type { get; set; }
        public Domain Domain { get; set; }
    }

    public enum Type
    {
        RSS
    }
}