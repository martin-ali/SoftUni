namespace Git.Services
{
    using System.Collections.Generic;
    using Git.Data.Models;
    using Git.ViewModels.Repositories;

    public interface IRepositoriesService
    {
        public void CreateRepository(RepositoryInputModel input, string ownerId);

        public IEnumerable<RepositoryViewModel> GetAllPublic();

        public Repository GetById(string id);
    }
}