namespace MiniORM.App
{
    using System;
    using System.Linq;
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;

    class Startup
    {
        static void Main()
        {
            var connectionString = "Server=NOTEBOOK-WIN;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Joe",
                LastName = "The Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
