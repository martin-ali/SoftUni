namespace Git.Data.Models
{
    using System.Collections.Generic;
    using Git.Common;

    public class User
    {
        public User()
        {
            this.Id = Helpers.NewId;
            this.Repositories = new List<Repository>();
            this.Commits = new List<Commit>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}