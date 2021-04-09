using DatabaseModel.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface IFeedService
    {
        Task<FeedService> CreateFeedService(FeedService newFeedService);
        Task<FeedService> DeleteFeedService(FeedService feedService);
        Task<FeedService> Update(FeedService feedServiceToBeUpdated, FeedService feedService);
        Task<IEnumerable<Feed>> GetFeedsByUserId(int id);
    }
}
