namespace _07_raw_data
{
    public class Tyre
    {
        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; private set; }

        public int Age { get; private set; }
    }
}