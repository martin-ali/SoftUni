namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;

    public class Motorcycle : IMotorcycle
    {
        public string Model => throw new System.NotImplementedException();

        public int HorsePower => throw new System.NotImplementedException();

        public double CubicCentimeters => throw new System.NotImplementedException();

        public double CalculateRacePoints(int laps)
        {
            throw new System.NotImplementedException();
        }
    }
}