using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class CookieToken
    {
        [Key] public int Id { get; set; }

        public Domain Domain { get; set; }
        public string Token { get; set; }
    }
}