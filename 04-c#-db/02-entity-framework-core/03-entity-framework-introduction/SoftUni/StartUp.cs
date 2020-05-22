namespace SoftUni
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();
            using (context)
            {
                // // 3. Employees Full Information
                // var var result = GetEmployeesFullInformation(context);

                // // 4. Employees with Salary Over 50 000
                // var result = GetEmployeesWithSalaryOver50000(context);

                // // 5. Employees from Research and Development
                // var result = GetEmployeesFromResearchAndDevelopment(context);

                // // 6. Adding a New Address and Updating Employee
                // var result = AddNewAddressToEmployee(context);

                // // 7. Employees and Projects
                // var result = GetEmployeesInPeriod(context);

                // // 8. Addresses by Town
                // var result = GetAddressesByTown(context);

                // // 9. Employee 147
                // var result = GetEmployee147(context);

                // // 10. Departments with More Than 5 Employees
                // var result = GetDepartmentsWithMoreThan5Employees(context);

                // // 11. Find Latest 10 Projects
                // var result = GetLatestProjects(context);

                // // 12. Increase Salaries
                // var result = IncreaseSalaries(context);

                // // 13. Find Employees by First Name Starting With "Sa"
                // var result = GetEmployeesByFirstNameStartingWithSa(context);

                // // 14. Delete Project by Id
                // var result = DeleteProjectById(context);

                // 15. Remove Town
                var result = RemoveTown(context);

                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                            .OrderBy(e => e.EmployeeId)
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.MiddleName,
                                e.JobTitle,
                                e.Salary
                            })
                            .ToList();

            var employeesInfoText = new StringBuilder();
            foreach (var employee in employees)
            {
                var info = $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:0.00}";
                employeesInfoText.AppendLine(info);
            }

            return employeesInfoText.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                            .OrderBy(e => e.FirstName)
                            .Where(e => e.Salary > 50000)
                            .Select(e => new
                            {
                                e.FirstName,
                                e.Salary
                            })
                            .ToList();

            var employeesInfoText = new StringBuilder();
            foreach (var employee in employees)
            {
                var info = $"{employee.FirstName} - {employee.Salary:0.00}";
                employeesInfoText.AppendLine(info);
            }

            return employeesInfoText.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                            .Where(e => e.Department.Name == "Research and Development")
                            .OrderBy(e => e.Salary)
                            .ThenByDescending(e => e.FirstName)
                            .Select(e => new
                            {
                                Name = $"{e.FirstName} {e.LastName}",
                                Department = e.Department.Name,
                                e.Salary
                            })
                            .ToList();

            var employeesInfoText = new StringBuilder();
            foreach (var employee in employees)
            {
                var info = $"{employee.Name} from {employee.Department} - ${employee.Salary:0.00}";
                employeesInfoText.AppendLine(info);
            }

            return employeesInfoText.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Employees
            .First(e => e.LastName == "Nakov")
            .Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees
                            .OrderByDescending(e => e.AddressId)
                            .Take(10)
                            .Select(e => e.Address.AddressText)
                            .ToList();

            var addressesText = new StringBuilder();
            foreach (var address in addresses)
            {
                addressesText.AppendLine(address);
            }


            return addressesText.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            // var employeesProjects = context.EmployeesProjects
            //                 .Take(10)
            //                 // .GroupBy(ep => ep.EmployeeId)
            //                 .Select(ep => new
            //                 {
            //                     EmployeeId = ep.EmployeeId,
            //                     EmployeeName = $"{ep.Employee.FirstName} {ep.Employee.LastName}",
            //                     ManagerName = $"{ep.Employee.Manager.FirstName} {ep.Employee.Manager.LastName}",
            //                     ProjectId = ep.Project.ProjectId,
            //                     ProjectName = ep.Project.Name,
            //                     ProjectStart = ep.Project.StartDate,
            //                     ProjectEnd = ep.Project.EndDate
            //                 })
            //                 .GroupBy(ep => new { ep.EmployeeId, ep.ProjectId })
            //                 .ToList();

            var employees = context.Employees
                           .Where(e => e.EmployeesProjects
                               .Any(p => 2001 <= p.Project.StartDate.Year
                                        && p.Project.StartDate.Year <= 2003))
                           .Select(e => new
                           {
                               Name = $"{e.FirstName} {e.LastName}",
                               ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                               Projects = e.EmployeesProjects.Select(ep => new
                               {
                                   ep.Project.Name,
                                   ep.Project.StartDate,
                                   ep.Project.EndDate
                               })
                           })
                           .Take(10)
                           .ToList();

            const string dateTimeFormat = "M/d/yyyy h:mm:ss tt";
            var employeesProjects = new StringBuilder();
            foreach (var employee in employees)
            {
                employeesProjects.AppendLine($"{employee.Name} - Manager: {employee.ManagerName}");
                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate.ToString(dateTimeFormat, CultureInfo.InvariantCulture);
                    var endDate = project.EndDate?.ToString(dateTimeFormat, CultureInfo.InvariantCulture) ?? "not finished";
                    employeesProjects.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return employeesProjects.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                            .OrderByDescending(a => a.Employees.Count)
                            .ThenBy(a => a.Town.Name)
                            .ThenBy(a => a.AddressText)
                            .Take(10)
                            .Select(a => new
                            {
                                EmployeeCount = a.Employees.Count,
                                TownName = a.Town.Name,
                                Text = a.AddressText
                            })
                            .ToList();

            var addressesText = new StringBuilder();
            foreach (var address in addresses)
            {
                addressesText.AppendLine($"{address.Text}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return addressesText.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                            .Where(e => e.EmployeeId == 147)
                            .Select(e => new
                            {
                                Name = $"{e.FirstName} {e.LastName}",
                                e.JobTitle,
                                Projects = e.EmployeesProjects
                                            .Select(ep => ep.Project.Name)
                                            .OrderBy(p => p)
                            })
                            .Single();

            var employeeText = new StringBuilder();
            employeeText.AppendLine($"{employee.Name} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                employeeText.AppendLine(project);
            }

            return employeeText.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                                .Where(d => d.Employees.Count > 5)
                                .OrderBy(d => d.Employees.Count)
                                .ThenBy(d => d.Name)
                                .Select(d => new
                                {
                                    d.Name,
                                    Manager = $"{d.Manager.FirstName} {d.Manager.LastName}",
                                    Employees = d.Employees
                                                .Select(e => new
                                                {
                                                    Name = $"{e.FirstName} {e.LastName}",
                                                    e.FirstName,
                                                    e.LastName,
                                                    e.JobTitle
                                                })
                                                .OrderBy(e => e.FirstName)
                                                .ThenBy(e => e.LastName)
                                })
                                .ToList();

            var departmentsText = new StringBuilder();
            foreach (var department in departments)
            {
                departmentsText.AppendLine($"{department.Name} - {department.Manager}");
                foreach (var employee in department.Employees)
                {
                    departmentsText.AppendLine($"{employee.Name} - {employee.JobTitle}");
                }
            }

            return departmentsText.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                            .OrderByDescending(p => p.StartDate)
                            .Take(10)
                            .OrderBy(p => p.Name)
                            .Select(p => new { p.Name, p.Description, p.StartDate })
                            .ToList();

            var projectsText = new StringBuilder();
            foreach (var project in projects)
            {
                projectsText.AppendLine(project.Name);
                projectsText.AppendLine(project.Description);
                projectsText.AppendLine($"{project.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return projectsText.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var validDepartments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employees = context.Employees
                            .Where(e => validDepartments.Contains(e.Department.Name))
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName);

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeeData = employees
                                .Select(e => new
                                {
                                    Name = $"{e.FirstName} {e.LastName}",
                                    e.Salary
                                })
                                .ToList();

            var employeesText = new StringBuilder();
            foreach (var employee in employeeData)
            {
                employeesText.AppendLine($"{employee.Name} (${employee.Salary:0.00})");
            }

            return employeesText.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                            .Where(e => e.FirstName.StartsWith("Sa"))
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .Select(e => new
                            {
                                Name = $"{e.FirstName} {e.LastName}",
                                e.JobTitle,
                                e.Salary
                            });

            var employeesText = new StringBuilder();
            foreach (var employee in employees)
            {
                employeesText.AppendLine($"{employee.Name} - {employee.JobTitle} - (${employee.Salary:0.00})");
            }

            return employeesText.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProjectsToRemove = context.EmployeesProjects
                                            .Where(ep => ep.ProjectId == 2)
                                            .ToList();
            var projectToRemove = context.Projects.Find(2);

            context.EmployeesProjects.RemoveRange(employeesProjectsToRemove);
            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projectsText = new StringBuilder();
            context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToList()
            .ForEach(p => projectsText.AppendLine(p));

            return projectsText.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                        .Single(t => t.Name == "Seattle");
            var addresses = context.Addresses
                            .Where(a => a.TownId == town.TownId)
                            .ToList();
            var employees = context.Employees
                            .Where(e => addresses.Contains(e.Address))
                            .ToList();

            var addressesCount = addresses.Count;

            foreach (var employee in employees)
            {
                employee.Address = null;
            }

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
/*

Scaffold-DbContext -Connection "Server=.;Database=SoftUni;Integrated Security=True;"-Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models
dotnet ef dbcontext scaffold "Server=NOTEBOOK-WIN;Database=SoftUni;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models

*/
