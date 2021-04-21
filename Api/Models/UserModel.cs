using Data.Objects;

namespace Api.Models
{
    public class UserModel
    {
        public UserModel(User user)
        {
            Username = user.Username;
            Email = user.Email;
        }

        public UserModel()
        {
        }

        public string Username { get; set; }
        public string Email { get; set; }

        public User ToUser(string passwordHash, string passwordSalt)
        {
            return new()
            {
                Username = Username,
                Email = Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }
    }
}