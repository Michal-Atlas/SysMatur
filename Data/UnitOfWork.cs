using System.Threading.Tasks;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SysMaturDbContext _context;
        private FeedRepository _feedRepository;
        private FeedRssRepository _feedRssRepository;
        private SessionTokenRepository _sessionTokenRepository;
        private UserRepository _userRepository;

        public UnitOfWork(SysMaturDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public IFeedRepository Feeds => _feedRepository ??= new FeedRepository(_context);

        public IFeedRssRepository FeedRss =>
            _feedRssRepository ??= new FeedRssRepository(_context);

        public ISessionTokenRepository SessionTokens =>
            _sessionTokenRepository ??= new SessionTokenRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}