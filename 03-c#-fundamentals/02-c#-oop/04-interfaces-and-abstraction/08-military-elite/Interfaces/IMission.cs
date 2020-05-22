namespace _08_military_elite.Interfaces
{
    using _08_military_elite.Models;

    public interface IMission
    {
        string CodeName { get; }

        string State { get; }
    }
}