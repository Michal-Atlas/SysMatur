using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SysMaturDbContext context)
            : base(context)
        { }

        Task<User> IUserRepository.GetUserByIdAsync(int id)
        {
            return SysMaturDbContext.Users.SingleOrDefaultAsync(a => a.Id == id);
        }
        private SysMaturDbContext SysMaturDbContext { get { return Context as SysMaturDbContext; } }
    }
}
