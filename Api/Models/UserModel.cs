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

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public User ToUser()
        {
            return new() {Username = Username, Email = Email, PasswordHash = PasswordHash, PasswordSalt = PasswordSalt};
        }
    }
}