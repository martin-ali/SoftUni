using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BattleCards.Data;
using BattleCards.Models;

namespace BattleCards.Services
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

        public void Create(string username, string email, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = new User(username, email, passwordHash);

            this.database.Users.Add(user);
            this.database.SaveChanges();
        }

        public bool EmailIsTaken(string email)
        {
            return this.database.Users.Any(u => u.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = this.database.Users.FirstOrDefault(u => u.Username == username && u.Password == passwordHash);

            return user?.Id;
        }

        public bool UsernameIsTaken(string username)
        {
            return this.database.Users.Any(u => u.Username == username);
        }
    }
}