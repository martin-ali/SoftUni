namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var serializer = new XmlSerializer(typeof(List<ExportProjectDto>),
                                          new XmlRootAttribute("Projects"));

            var projects = context.Projects
                            .Where(p => p.Tasks.Count >= 1)
                            .OrderByDescending(p => p.Tasks.Count())
                            .ThenBy(p => p.Name)
                            .Select(p => new ExportProjectDto
                            {
                                TasksCount = p.Tasks.Count,
                                ProjectName = p.Name,
                                HasEndDate = p.DueDate != null
                                    ? "Yes"
                                    : "No",
                                Tasks = p.Tasks
                                        .OrderBy(t => t.Name)
                                        .Select(t => new ExportTaskDto
                                        {
                                            Name = t.Name,
                                            Label = t.LabelType.ToString()
                                        })
                                        .ToList()
                            })
                            .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xml = new StringBuilder();
            var writer = new StringWriter(xml);
            using (writer)
            {
                serializer.Serialize(writer, projects, namespaces);
            }

            return xml.ToString();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployees = context.Employees
                                    .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                                    .Select(e => new
                                    {
                                        e.Username,
                                        Tasks = e.EmployeesTasks
                                                .Where(et => et.Task.OpenDate >= date)
                                                .OrderByDescending(et => et.Task.DueDate)
                                                .ThenBy(et => et.Task.Name)
                                                .Select(et => new
                                                {
                                                    TaskName = et.Task.Name,
                                                    OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                                    DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                                    LabelType = et.Task.LabelType.ToString(),
                                                    ExecutionType = et.Task.ExecutionType.ToString()
                                                })
                                    })
                                    .OrderByDescending(e => e.Tasks.Count())
                                    .ThenBy(e => e.Username)
                                    .Take(10)
                                    .ToList();

            var json = JsonConvert.SerializeObject(busiestEmployees);

            return json;
        }
    }
}