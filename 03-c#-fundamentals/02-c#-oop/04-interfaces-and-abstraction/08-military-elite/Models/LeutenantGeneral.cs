namespace _08_military_elite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using _08_military_elite.Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IEnumerable<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IEnumerable<IPrivate> Privates { get; }

        public override string ToString()
        {
            var information = new StringBuilder();

            information.AppendLine($"{base.ToString()}");
            information.AppendLine("Privates:");
            foreach (var privateInfo in this.Privates)
            {
                information.AppendLine($"  {privateInfo.ToString()}");
            }

            return information.ToString().TrimEnd();
        }
    }
}