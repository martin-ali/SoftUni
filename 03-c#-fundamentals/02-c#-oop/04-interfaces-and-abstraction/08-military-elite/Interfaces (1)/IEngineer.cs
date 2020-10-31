namespace _08_military_elite.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; }
    }
}