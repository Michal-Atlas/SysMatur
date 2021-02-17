using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        public string DisplayName { get; set; }
        public string Auth0Sub { get; set; }
        public List<CookieToken> CookieTokens { get; set; }
        public List<View> Views { get; set; }
        public List<Feed> Feeds { get; set; }
    }
}