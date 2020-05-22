namespace _08_military_elite.Models
{
    using System;
    using _08_military_elite.Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            var corpsIsValid = corps == "Airforces" || corps == "Marines";
            if (corpsIsValid == false)
            {
                throw new ArgumentException();
            }

            this.Corps = corps;
        }

        public string Corps { get; }
    }
}