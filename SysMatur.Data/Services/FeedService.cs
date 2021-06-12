using System.Collections.Generic;
using System.Threading.Tasks;
using SysMatur.Data.Objects;

namespace SysMatur.Data.Services
{
    public class FeedService : IFeedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Feed> IFeedService.CreateFeed(Feed newFeed)
        {
            await _unitOfWork.Feeds.CreateAsync(newFeed);
            await _unitOfWork.CommitAsync();
            return newFeed;
        }

        async Task IFeedService.DeleteFeed(Feed feed)
        {
            _unitOfWork.Feeds.Remove(feed);
            await _unitOfWork.CommitAsync();
        }

        async Task<IEnumerable<Feed>> IFeedService.GetFeedsByUserId(int id)
        {
            return await _unitOfWork.Feeds.GetByUserIdAsync(id);
        }

        public async Task<Feed> CreateAsync(Feed toFeed)
        {
            return await _unitOfWork.Feeds.CreateAsync(toFeed);
        }

        public async Task<bool> CheckOwnership(int userId, int feedId)
        {
            return await _unitOfWork.Feeds.CheckOwnership(userId, feedId);
        }

        public async Task SetVisibility(int feedId, bool visibility)
        {
            await _unitOfWork.Feeds.SetVisibility(feedId, visibility);
        }

        public async Task ChangeUrl(int feedId, string? url)
        {
            await _unitOfWork.Feeds.ChangeUrl(feedId, url);
        }

        public async Task DeleteAsync(int feedId)
        {
            await _unitOfWork.Feeds.DeleteAsync(feedId);
        }

        public async Task<IEnumerable<Feed>> GetByUsernameAsync(string userUsername)
        {
            return await _unitOfWork.Feeds.GetByUsernameAsync(userUsername);
        }
    }
}