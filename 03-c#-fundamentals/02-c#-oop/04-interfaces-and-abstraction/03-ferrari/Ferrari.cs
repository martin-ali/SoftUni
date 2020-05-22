namespace _03_ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string DriverName { get; }

        public string Model { get; } = "488-Spider";

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.PushBrakes()}/{this.PushGas()}/{this.DriverName}";
        }
    }
}