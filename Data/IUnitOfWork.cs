using System;
using System.Threading.Tasks;
using SysMatur.Data.Repositories;

namespace SysMatur.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public IFeedRepository Feeds { get; }
        public ISessionTokenRepository SessionTokens { get; }
        public Task<int> CommitAsync();
    }
}