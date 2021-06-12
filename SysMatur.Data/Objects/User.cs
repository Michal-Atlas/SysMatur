using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SysMatur.Data.Objects
{
    public class User
    {
        public User()
        {
            Feeds = new List<Feed>();
            SessionTokens = new List<SessionToken>();
        }

        [Key] public int Id { get; set; }

        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public List<Feed> Feeds { get; set; }
        public List<SessionToken> SessionTokens { get; set; }
    }
}