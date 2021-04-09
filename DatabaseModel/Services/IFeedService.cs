using Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface IFeedService
    {
        Task<Feed> CreateFeed(Feed newFeed);
        Task DeleteFeed(Feed feed);
        Task Update(Feed feedToBeUpdated, Feed feed);
        Task<IEnumerable<Feed>> GetFeedsByUserId(int id);
    }
}
