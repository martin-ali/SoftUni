namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using Newtonsoft.Json;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<ImportProjectDto>),
                                            new XmlRootAttribute("Projects"));

            var projectDtos = (List<ImportProjectDto>)serializer.Deserialize(new StringReader(xmlString));
            var result = new StringBuilder();

            foreach (var projectDto in projectDtos)
            {
                var importResult = ErrorMessage;
                bool projectDtoIsValid = IsValid(projectDto) == false;
                if (projectDtoIsValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = ParseDate(projectDto.OpenDate),
                    DueDate = string.IsNullOrWhiteSpace(projectDto.DueDate)
                    ? null
                    : (DateTime?)ParseDate(projectDto.DueDate)
                };

                if (IsValid(project) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var taskDto in projectDto.Tasks.Distinct())
                {
                    bool taskDtoIsValid = IsValid(taskDto)
                        && !string.IsNullOrWhiteSpace(taskDto.DueDate)
                        && !string.IsNullOrWhiteSpace(taskDto.OpenDate)
                        && IsValidEnum<ExecutionType>(taskDto.ExecutionType)
                        && IsValidEnum<LabelType>(taskDto.LabelType);

                    if (taskDtoIsValid == false)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = ParseDate(taskDto.OpenDate),
                        DueDate = ParseDate(taskDto.DueDate),
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    var taskIsValid = IsValid(task)
                        && task.DueDate > task.OpenDate
                        && task.OpenDate > project.OpenDate;

                    if (project.DueDate != null)
                    {
                        taskIsValid &= task.DueDate < project.DueDate;
                    }

                    if (taskIsValid == false)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(task);
                }

                context.Projects.Add(project);

                importResult = string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count);

                result.AppendLine(importResult);
            }

            context.SaveChanges();

            return result.ToString();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeeDtos = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);
            var result = new StringBuilder();

            foreach (var employeeDto in employeeDtos)
            {
                var importResult = ErrorMessage;
                try
                {
                    if (IsValid(employeeDto))
                    {
                        var employee = new Employee
                        {
                            Username = employeeDto.Username,
                            Email = employeeDto.Email,
                            Phone = employeeDto.Phone
                        };

                        foreach (var taskId in employeeDto.Tasks.Distinct())
                        {
                            if (context.Tasks.Find(taskId) != null)
                            {
                                employee.EmployeesTasks.Add(new EmployeeTask { TaskId = taskId });
                            }
                            else
                            {
                                result.AppendLine(ErrorMessage);
                            }
                        }

                        context.Employees.Add(employee);

                        importResult = string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count);
                    }
                }
                catch (System.Exception)
                {
                }

                result.AppendLine(importResult);
            }

            context.SaveChanges();
            return result.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static bool IsValidEnum<T>(int input)
        {
            return Enum.IsDefined(typeof(T), input);
        }

        private static DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}