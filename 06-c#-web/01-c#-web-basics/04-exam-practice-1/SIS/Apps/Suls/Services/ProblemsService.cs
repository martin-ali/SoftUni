using System.Collections.Generic;
using System.Linq;
using Suls.Data;
using Suls.ViewModels.Problems;
using Suls.ViewModels.Submissions;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext database;

        public ProblemsService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Create(string name, ushort points)
        {
            var problem = new Problem(name, points);

            this.database.Problems.Add(problem);
            this.database.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.database.Problems
                .Select(p => new HomePageProblemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count
                })
                .ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            var problem = this.database.Problems
                .Where(p => p.Id == id)
                .Select(p => p.Name)
                .FirstOrDefault();

            return problem;
        }

        public ProblemViewModel GetById(string id)
        {
            var problem = this.database.Problems
                .Where(p => p.Id == id)
                .Select(p => new ProblemViewModel
                {
                    Name = p.Name,
                    Submissions = p.Submissions
                        .Select(s => new SubmissionViewModel
                        {
                            SubmissionId = s.Id,
                            Username = s.User.Username,
                            CreatedOn = s.CreatedOn,
                            AchievedResult = s.AchievedResult,
                            MaxPoints = p.Points
                        })
                })
                .FirstOrDefault();

            return problem;
        }
    }
}