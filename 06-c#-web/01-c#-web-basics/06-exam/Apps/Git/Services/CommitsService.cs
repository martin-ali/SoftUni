namespace Git.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;

    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext database;

        public CommitsService(ApplicationDbContext database)
        {
            this.database = database;
        }


        public void CreateCommit(CommitInputModel input, string creatorId)
        {
            var commit = new Commit
            {
                Description = input.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = creatorId,
                RepositoryId = input.RepositoryId
            };

            var repository = this.database.Repositories.Find(input.RepositoryId);
            this.database.Commits.Add(commit);
            // repository.Commits.Add(commit);

            this.database.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAllByUserId(string userId)
        {
            var commits = this.database.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new CommitViewModel
                {
                    Id = c.Id,
                    RepositoryName = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn
                })
                .ToList();

            return commits;
        }


        public Commit GetById(string id)
        {
            var commit = this.database.Commits.Find(id);

            return commit;
        }

        public CommitCreaterepositoryViewModel GetRepositoryById(string id)
        {
            var repository = this.database.Repositories.Find(id);
            var repositoryViewModel = new CommitCreaterepositoryViewModel
            {
                RepositoryId = repository.Id,
                RepositoryName = repository.Name
            };

            return repositoryViewModel;
        }

        public void DeleteById(string commitId)
        {
            var commit = this.database.Commits.Find(commitId);

            this.database.Commits.Remove(commit);
            this.database.SaveChanges();
        }
    }
}