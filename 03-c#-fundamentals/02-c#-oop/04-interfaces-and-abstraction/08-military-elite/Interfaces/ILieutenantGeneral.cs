namespace _08_military_elite.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        IEnumerable<IPrivate> Privates { get; }

    }
}