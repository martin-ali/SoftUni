using System;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Submission(string problemId, string userId, string code, ushort achievedResult, DateTime createdOn)
            : this()
        {
            this.ProblemId = problemId;
            this.UserId = userId;
            this.Code = code;
            this.AchievedResult = achievedResult;
            this.CreatedOn = createdOn;
        }

        public string Id { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]  // Value types are always required since they can't be null. Nullable value types may or may not be required
        [Range(0, 300)] // Inclusive
        public ushort AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public virtual Problem Problem { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}