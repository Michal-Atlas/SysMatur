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

        async Task<User> IUserService.CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        async Task IUserService.DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        async Task IUserService.Update(User userToBeUpdated, User user)
        {
            userToBeUpdated = user;
            await _unitOfWork.CommitAsync();
        }
    }
}