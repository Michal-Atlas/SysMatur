using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal class FeedRedditApiService : IFeedRedditApiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedRedditApiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<FeedRedditApi> IFeedRedditApiService.CreateFeedRedditApi(FeedRedditApi newFeedRedditApi)
        {
            await _unitOfWork.FeedRedditApis.AddAsync(newFeedRedditApi);
            await _unitOfWork.CommitAsync();
            return newFeedRedditApi;
        }

        async Task IFeedRedditApiService.DeleteFeedRedditApi(FeedRedditApi feedRedditApi)
        {
            _unitOfWork.FeedRedditApis.Remove(feedRedditApi);
            await _unitOfWork.CommitAsync();
        }

        async Task IFeedRedditApiService.Update(FeedRedditApi feedRedditApiToBeUpdated, FeedRedditApi feedRedditApi)
        {
            feedRedditApiToBeUpdated = feedRedditApi;
            await _unitOfWork.CommitAsync();
        }
    }
}