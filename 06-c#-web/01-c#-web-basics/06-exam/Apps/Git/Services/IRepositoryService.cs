namespace Git.Services
{
    using System.Collections.Generic;
    using Git.ViewModels.Repositories;

    public interface IRepositoriesService
    {
        public void CreateRepository(RepositoryInputModel input, string ownerId);

        public IEnumerable<RepositoryViewModel> GetAllPublic();
    }
}