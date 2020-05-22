namespace _08_military_elite.Models
{
    using System;
    using _08_military_elite.Interfaces;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            var stateIsValid = state == "inProgress" || state == "Finished";
            if (stateIsValid == false)
            {
                throw new ArgumentException();
            }

            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public string State { get; private set; }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}