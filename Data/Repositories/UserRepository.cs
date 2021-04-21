using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SysMaturDbContext context)
            : base(context)
        {
        }

        private SysMaturDbContext SysMaturDbContext => Context;

        Task<User> IUserRepository.GetUserByIdAsync(int id)
        {
            return SysMaturDbContext.Users.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<SessionToken>> GetWithSessionTokensByIdAsync(int userId)
        {
            return SysMaturDbContext.Users.Include(x => x.SessionTokens).FirstAsync(x => x.Id == userId).Result
                .SessionTokens;
        }

        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            return await SysMaturDbContext.Users.FirstOrDefaultAsync(x => x.Username == userName);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await SysMaturDbContext.Users.AddAsync(user);
            SysMaturDbContext.SaveChangesAsync();
            return user;
        }
    }
}