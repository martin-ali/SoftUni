namespace _08_military_elite.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        ISet<IMission> Missions { get; }
    }
}