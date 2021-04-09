using Data;
using Data.Objects;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Services
{
    class FeedService : IFeedService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        async Task<Feed> IFeedService.CreateFeed(Feed newFeed)
        {
            await _unitOfWork.Feeds.AddAsync(newFeed);
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
            return await _unitOfWork.Feeds.GetFeedsByUserIdAsync(id);
        }

        async Task IFeedService.Update(Feed feedToBeUpdated, Feed feed)
        {
            feedToBeUpdated = feed;
            await _unitOfWork.CommitAsync();
        }
    }
}
