using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly SysMaturDbContext _context;
        private UserRepository _userRepository;
        private FeedRedditApiRepository _feedRedditApiRepository;
        private FeedRepository _feedRepository;
        private SessionTokenRepository _sessionTokenRepository;

        IUserRepository IUnitOfWork.Users => _userRepository = _userRepository ?? new UserRepository(_context);

        IFeedRepository IUnitOfWork.Feeds => _feedRepository = _feedRepository ?? new FeedRepository(_context);

        IFeedRedditApiRepository IUnitOfWork.FeedRedditApis => _feedRedditApiRepository = _feedRedditApiRepository ?? new FeedRedditApiRepository(_context);

        ISessionTokenRepository IUnitOfWork.SessionTokens => _sessionTokenRepository = _sessionTokenRepository ?? new SessionTokenRepository(_context);

        async Task<int> IUnitOfWork.CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}
