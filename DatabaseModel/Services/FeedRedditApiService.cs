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
    class FeedRedditApiService : IFeedRedditApiService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedRedditApiService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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

