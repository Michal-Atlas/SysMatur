using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        public string UserName { get; set; }
        public string PassHash { get; set; }
        public string Salt { get; set; }
        public List<CookieToken> CookieTokens { get; set; }
        public List<View> Views { get; set; }
        public List<RSSFeed> RssFeeds { get; set; }
    }
}