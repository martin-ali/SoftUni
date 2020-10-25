using System;
using System.Linq;
using Suls.Data;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext database;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext database, Random random)
        {
            this.database = database;
            this.random = random;
        }
        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.database.Problems
                .Where(p => p.Id == problemId)
                .Select(p => p.Points)
                .FirstOrDefault();
            var achievedResult = (ushort)this.random.Next(0, problemMaxPoints + 1);
            var createdOn = DateTime.UtcNow;
            var submission = new Submission(problemId, userId, code, achievedResult, createdOn);

            this.database.Submissions.Add(submission);
            this.database.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.database.Submissions.Find(id);
            this.database.Submissions.Remove(submission);

            this.database.SaveChanges();
        }
    }
}