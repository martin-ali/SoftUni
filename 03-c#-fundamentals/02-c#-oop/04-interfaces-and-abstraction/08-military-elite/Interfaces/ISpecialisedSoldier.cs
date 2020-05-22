namespace _08_military_elite.Interfaces
{
    using _08_military_elite.Models;

    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }
}