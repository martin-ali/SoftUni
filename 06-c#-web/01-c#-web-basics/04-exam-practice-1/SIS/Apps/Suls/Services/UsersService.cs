using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Suls.Data;

namespace Suls.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext database;

        public UsersService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User(username, email, ComputeHash(password));

            this.database.Users.Add(user);
            this.database.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = this.database.Users.FirstOrDefault(u => u.Username == username && u.Password == passwordHash);

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.database.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.database.Users.Any(u => u.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to Text
            // StringBuilder capacity is 128 bytes because 512 bits / 8 bits = 128
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var hashedByte in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(hashedByte.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}