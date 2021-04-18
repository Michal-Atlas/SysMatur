using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        public FeedRepository(SysMaturDbContext context)
            : base(context)
        {
        }

        private SysMaturDbContext SysMaturDbContext => Context;

        Task<Feed> IFeedRepository.GetFeedByIdAsync(int id)
        {
            return SysMaturDbContext.Feeds.SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Feed>> GetFeedsByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}