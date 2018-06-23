using System;

namespace _08_employee_data
{
    class EmployeeData
    {
        static void Main()
        {
            string firstName = "Amanda";
            string lastName = "Jonson";
            byte age = 27;
            char gender = 'f';
            string personalId = "8306112507";
            int uniqueEmployeeNumber = 27563571;

            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {lastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {personalId}");
            Console.WriteLine($"Unique Employee number: {uniqueEmployeeNumber}");
        }
    }
}
