using System;
using System.Threading.Tasks;
using Data.Repositories;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public IFeedRepository Feeds { get; }
        public IFeedRssRepository FeedRss { get; }
        public ISessionTokenRepository SessionTokens { get; }
        public Task<int> CommitAsync();
    }
}