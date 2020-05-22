namespace _04_hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        private Patient[] patients = new Patient[3];

        public int OccupiedBedsCount { get; private set; } = 0;

        public bool HasEmptyBeds => this.OccupiedBedsCount < this.patients.Length;

        public IReadOnlyCollection<Patient> Patients
        {
            get
            {
                return this.patients.Where(p => p != null).ToList().AsReadOnly();
            }
        }

        public void AddPatient(Patient patient)
        {
            if (this.OccupiedBedsCount == 3)
            {
                throw new InvalidOperationException();
            }

            this.patients[OccupiedBedsCount] = patient;

            this.OccupiedBedsCount++;
        }
    }
}