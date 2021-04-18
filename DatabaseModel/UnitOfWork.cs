using System;
using System.Threading.Tasks;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SysMaturDbContext _context;
        private FeedRedditApiRepository _feedRedditApiRepository;
        private FeedRepository _feedRepository;
        private SessionTokenRepository _sessionTokenRepository;
        private UserRepository _userRepository;

        IUserRepository IUnitOfWork.Users => _userRepository = _userRepository ?? new UserRepository(_context);

        IFeedRepository IUnitOfWork.Feeds => _feedRepository = _feedRepository ?? new FeedRepository(_context);

        IFeedRedditApiRepository IUnitOfWork.FeedRedditApis => _feedRedditApiRepository =
            _feedRedditApiRepository ?? new FeedRedditApiRepository(_context);

        ISessionTokenRepository IUnitOfWork.SessionTokens => _sessionTokenRepository =
            _sessionTokenRepository ?? new SessionTokenRepository(_context);

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