using api.DbModel.Objects;
using Microsoft.EntityFrameworkCore;

namespace api.DbModel
{
    public class SysMaturDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<RedditApi> RedditApis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            // => options.UseSqlite("Data Source=blogging.db");
            => options.UseNpgsql(@"host=localhost; database=SysMatur_T;user id=postgres; password=Temp1234");
    }
}