using DatabaseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModel
{
    public class SysMaturDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<RSSFeed> RssFeeds { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<CookieToken> CookieTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            //    => options.UseSqlite("Data Source=blogging.db");
            => options.UseSqlServer("Server=localhost; Uid=sa; Pwd=Temp1234");
    }
}