namespace Git.Services
{
    using System.Collections.Generic;
    using Git.Data.Models;
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;

    public interface ICommitsService
    {
        public void CreateCommit(CommitInputModel input, string creatorId);

        public IEnumerable<CommitViewModel> GetAllByUserId(string userId);

        public void DeleteById(string commitId);

        public Commit GetById(string id);
    }
}