using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Git.Data;
using Git.Data.Models;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext database;

        public UsersService(ApplicationDbContext database)
        {
            this.database = database;
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var hashedByte in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(hashedByte.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }

        public string CreateUser(string username, string email, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = new User
            {
                Username = username,
                Email = email,
                Password = passwordHash
            };

            this.database.Users.Add(user);
            this.database.SaveChanges();

            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = this.database.Users.FirstOrDefault(u => u.Username == username && u.Password == passwordHash);

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            var emailIsAvailable = !this.database.Users.Any(u => u.Email == email);

            return emailIsAvailable;
        }

        public bool IsUsernameAvailable(string username)
        {
            var usernameIsAvailable = !this.database.Users.Any(u => u.Username == username);

            return usernameIsAvailable;
        }
    }
}