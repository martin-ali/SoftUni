namespace _04_hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var hospital = new Hospital();

            var input = Console.ReadLine();
            while (input != "Output")
            {
                var parameters = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var department = parameters[0];
                var doctorFirstName = parameters[1];
                var doctorSurname = parameters[2];
                var patientName = parameters[3];

                var patient = new Patient(patientName);

                if (hospital.HasDepartment(department) == false)
                {
                    hospital.AddDepartment(department);
                }

                if (hospital.HasDoctor(doctorFirstName, doctorSurname) == false)
                {
                    hospital.AddDoctor(doctorFirstName, doctorSurname);
                }

                if (hospital.DepartmentHasFreeBeds(department))
                {
                    hospital.AssignPatientToDepartment(patient, department);
                    hospital.AssignPatientToDoctor(patient, doctorFirstName, doctorSurname);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                var parameters = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IEnumerable<Patient> patients = null;
                if (parameters.Length == 2 && int.TryParse(parameters[1], out int roomNumber))
                {
                    var departmentName = parameters[0];

                    patients = hospital
                                .GetDepartmentByName(departmentName)
                                .GetRoom(roomNumber)
                                .Patients
                                .OrderBy(p => p.Name);
                }
                else if (parameters.Length == 2 && hospital.HasDoctor(parameters[0], parameters[1]))
                {
                    var firstName = parameters[0];
                    var surname = parameters[1];
                    var doctor = hospital.GetDoctor(firstName, surname);

                    patients = doctor.Patients.OrderBy(p => p.Name);
                }
                else if (hospital.HasDepartment(parameters[0]))
                {
                    var departmentName = parameters[0];
                    var department = hospital.GetDepartmentByName(departmentName);

                    patients = department.Patients;
                }

                foreach (var patient in patients)
                {
                    Console.WriteLine(patient);
                }

                input = Console.ReadLine();
            }
        }
    }
}
/*

Cardiology Petar Petrov Ventsi
Oncology Ivaylo Kenov Valio
Emergency Mariq Mircheva Simo
Cardiology Genka Shikerova Simon
Emergency Ivaylo Kenov NuPogodi
Cardiology Gosho Goshov Esmeralda
Oncology Gosho Goshov Cleopatra
Output
Cardiology
End

Cardiology Petar Petrov Ventsi
Oncology Ivaylo Kenov Valio
Emergency Mariq Mircheva Simo
Cardiology Genka Shikerova Simon
Emergency Ivaylo Kenov NuPogodi
Cardiology Gosho Goshov Esmeralda
Oncology Gosho Goshov Cleopatra
Output
Cardiology 1
End

Cardiology Petar Petrov Ventsi
Oncology Ivaylo Kenov Valio
Emergency Mariq Mircheva Simo
Cardiology Genka Shikerova Simon
Emergency Ivaylo Kenov NuPogodi
Cardiology Gosho Goshov Esmeralda
Oncology Gosho Goshov Cleopatra
Output
Ivaylo Kenov
End

*/
