using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
