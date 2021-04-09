using Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    interface IFeedRedditApiRepository : IRepository<FeedRedditApi>
    {
        Task<FeedRedditApi> GetFeedRedditApiByIdAsync(int id);
    }
}
