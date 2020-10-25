namespace Git.Common
{
    public class Constants
    {
        // User
        public const int UsernameMinLength = 5;
        public const int UsernameМaxLength = 20;

        public const int PasswordMinLength = 6;
        public const int PasswordМaxLength = 20;

        // Repository
        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;
        public static readonly string[] AllowedRepositoryTypes = new[] { "Public", "Private" };

        // Commit
        public const int CommitDescriptionMinLength = 5;
    }
}