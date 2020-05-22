namespace _04_hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        private Dictionary<string, Department> departmentByName = new Dictionary<string, Department>();

        private Dictionary<string, Doctor> doctorByFullName = new Dictionary<string, Doctor>();

        public Department GetDepartmentByName(string name) => this.departmentByName[name];

        public Doctor GetDoctor(string fullName) => this.doctorByFullName[fullName];

        public Doctor GetDoctor(string firstName, string surname) => this.doctorByFullName[Doctor.GenerateFullName(firstName, surname)];

        public bool DepartmentHasFreeBeds(string department)
        {
            if (this.HasDepartment(department)
                && this.GetDepartmentByName(department).HasUnoccupiedBeds)
            {
                return true;
            }

            return false;
        }

        public bool HasDoctor(string firstName, string surname)
        {
            var fullName = Doctor.GenerateFullName(firstName, surname);

            var doctorExists = this.doctorByFullName.ContainsKey(fullName);
            return doctorExists;
        }

        public bool HasDoctor(string fullName)
        {
            var doctorExists = this.doctorByFullName.ContainsKey(fullName);
            return doctorExists;
        }

        public bool HasDepartment(string department)
        {
            var departmentExists = this.departmentByName.ContainsKey(department);

            return departmentExists;
        }

        public void AddDepartment(string department)
        {
            var newDepartment = new Department(department);
            this.departmentByName[department] = newDepartment;
        }

        public void AddDoctor(string firstName, string surname)
        {
            var newDoctor = new Doctor(firstName, surname);
            this.doctorByFullName[newDoctor.FullName] = newDoctor;
        }

        public void AssignPatientToDepartment(Patient patient, string department)
        {
            this.departmentByName[department].AddPatient(patient);
        }

        public void AssignPatientToDoctor(Patient patient, string doctorFirstName, string doctorSurname)
        {
            this.GetDoctor(doctorFirstName, doctorSurname).AddPatient(patient);
        }
    }
}