using System;
using System.Threading.Tasks;
using Data.Repositories;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IFeedRepository Feeds { get; }
        IFeedRedditApiRepository FeedRedditApis { get; }
        ISessionTokenRepository SessionTokens { get; }
        Task<int> CommitAsync();
    }
}