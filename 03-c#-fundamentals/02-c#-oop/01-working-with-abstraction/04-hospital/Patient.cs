namespace _04_hospital
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}