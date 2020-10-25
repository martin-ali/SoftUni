namespace Git.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Repositories;

    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext database;

        public RepositoriesService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void CreateRepository(RepositoryInputModel input, string ownerId)
        {
            var repository = new Repository
            {
                Name = input.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = input.RepositoryType == "Public",
                OwnerId = ownerId
            };

            this.database.Repositories.Add(repository);
            this.database.SaveChanges();

        }

        public IEnumerable<RepositoryViewModel> GetAllPublic()
        {
            var publicRepositories = this.database.Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    OwnerUsername = r.Owner.Username,
                    CreatedOn = r.CreatedOn,
                    CommitsCount = r.Commits.Count()
                })
                .ToList();

            return publicRepositories;
        }
    }
}