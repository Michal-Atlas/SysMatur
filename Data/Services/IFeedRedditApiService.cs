using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal interface IFeedRedditApiService
    {
        Task<FeedRedditApi> CreateFeedRedditApi(FeedRedditApi newFeedRedditApi);
        Task DeleteFeedRedditApi(FeedRedditApi feedRedditApi);
        Task Update(FeedRedditApi feedRedditApiToBeUpdated, FeedRedditApi feedRedditApi);
    }
}