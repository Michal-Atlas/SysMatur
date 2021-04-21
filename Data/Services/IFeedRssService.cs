using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal interface IFeedRssService
    {
        Task<FeedRss> CreateFeedRss(FeedRss newFeedRss);
        Task DeleteFeedRss(FeedRss feedRss);
        Task Update(FeedRss feedRssToBeUpdated, FeedRss feedRss);
    }
}