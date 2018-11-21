using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var employeeByDepartment = new Dictionary<string, List<Employee>>();
            var employeeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < employeeCount; i++)
            {
                var data = Console.ReadLine().Split();
                var name = data[0];
                var salary = decimal.Parse(data[1]);
                var position = data[2];
                var department = data[3];

                var newEmployee = new Employee(name, salary, position, department);

                if (data.Length > 4)
                {
                    var additionalData = data[4];
                    if (int.TryParse(additionalData, out int age))
                    {
                        newEmployee.Age = age;
                    }
                    else
                    {
                        newEmployee.Email = additionalData;
                    }
                }

                if (data.Length > 5)
                {
                    var age = data[5];
                    newEmployee.Age = int.Parse(age);
                }

                if (employeeByDepartment.ContainsKey(department) == false)
                {
                    employeeByDepartment[department] = new List<Employee>();
                }

                employeeByDepartment[department].Add(newEmployee);
            }

            var bestPaidDepartment = employeeByDepartment
                                        .OrderByDescending(dep => dep.Value.Average(emp => emp.Salary))
                                        .First();

            Console.WriteLine($"Highest Average Salary: {bestPaidDepartment.Key}");
            foreach (var employee in bestPaidDepartment.Value.OrderByDescending(emp => emp.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:0.00} {employee.Email} {employee.Age}");
            }
        }
    }
}