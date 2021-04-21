using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal class FeedRssService : IFeedRssService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedRssService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FeedRss> CreateFeedRss(FeedRss newFeedRss)
        {
            await _unitOfWork.FeedRss.AddAsync(newFeedRss);
            await _unitOfWork.CommitAsync();
            return newFeedRss;
        }

        public async Task DeleteFeedRss(FeedRss feedRss)
        {
            _unitOfWork.FeedRss.Remove(feedRss);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(FeedRss feedRssToBeUpdated, FeedRss feedRss)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}