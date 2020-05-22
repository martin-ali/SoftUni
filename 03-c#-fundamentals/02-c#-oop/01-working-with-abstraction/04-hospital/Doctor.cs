namespace _04_hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Doctor
    {
        private List<Patient> patients = new List<Patient>();

        public Doctor(string firstName, string surname)
        {
            this.FirstName = firstName;
            this.Surname = surname;
        }

        public string FirstName { get; private set; }

        public string Surname { get; private set; }

        public string FullName => GenerateFullName(this.FirstName, this.Surname);

        public IReadOnlyCollection<Patient> Patients
        {
            get
            {
                return this.patients
                        .ToList()
                        .AsReadOnly();
            }
        }

        public static string GenerateFullName(string firstName, string surname)
        {
            return $"{firstName} {surname}";
        }

        public void AddPatient(Patient patient)
        {
            this.patients.Add(patient);
        }
    }
}