namespace _03_ferrari
{
    public interface ICar
    {
        string DriverName { get; }

        string PushBrakes();

        string PushGas();
    }
}