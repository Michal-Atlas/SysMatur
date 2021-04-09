using Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface IFeedRedditApiService
    {
        Task<FeedRedditApi> CreateFeedRedditApi(FeedRedditApi newFeedRedditApi);
        Task DeleteFeedRedditApi(FeedRedditApi feedRedditApi);
        Task Update(FeedRedditApi feedRedditApiToBeUpdated, FeedRedditApi feedRedditApi);
    }
}
