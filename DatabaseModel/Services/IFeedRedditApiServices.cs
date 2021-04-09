using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface IFeedRedditApiServices
    {
        Task<FeedRedditApi> CreateFeedRedditApi(FeedRedditApi newFeedRedditApi);
        Task<FeedRedditApi> DeleteFeedRedditApi(FeedRedditApi feedRedditApi);
        Task<FeedRedditApi> Update(FeedRedditApi feedRedditApiToBeUpdated, FeedRedditApi feedRedditApi);
    }
}
