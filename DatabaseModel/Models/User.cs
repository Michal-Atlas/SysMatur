using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class User
    {
        public User()
        {
            Feeds = new List<Feed>();
            Views = new List<View>();
            CookieTokens = new List<CookieToken>();
        }

        [Key] public int Id { get; set; }

        public string DisplayName { get; set; }
        public string Auth0Sub { get; set; }
        public List<CookieToken> CookieTokens { get; set; }
        public List<View> Views { get; set; }
        public List<Feed> Feeds { get; set; }
    }
}