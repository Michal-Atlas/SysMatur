using System;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetUserByIdAsync(id);
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(User userToBeUpdated, User user)
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserBySessionToken(string sessionKey)
        {
            return await _unitOfWork.SessionTokens.GetUserFromSessionToken(sessionKey);
        }
    }
}