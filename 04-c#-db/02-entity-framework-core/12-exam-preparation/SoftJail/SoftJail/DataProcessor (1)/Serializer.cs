namespace SoftJail.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                            .Where(p => ids.Contains(p.Id))
                            .OrderBy(p => p.FullName)
                            .ThenBy(p => p.Id)
                            .Select(p => new
                            {
                                p.Id,
                                Name = p.FullName,
                                p.Cell.CellNumber,
                                Officers = p.PrisonerOfficers
                                            .OrderBy(po => po.Officer.FullName)
                                            .ThenBy(po => po.PrisonerId)
                                            .Select(po => new
                                            {
                                                OfficerName = po.Officer.FullName,
                                                Department = po.Officer.Department.Name
                                            }),
                                TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                            })
                            .ToList();

            var json = JsonConvert.SerializeObject(prisoners);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var serializer = new XmlSerializer(typeof(List<ExportPrisonerDto>),
                                            new XmlRootAttribute("Prisoners"));

            var names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var prisoners = context.Prisoners
                            .Where(p => names.Contains(p.FullName))
                            .OrderBy(p => p.FullName)
                            .ThenBy(p => p.Id)
                            .ProjectTo<ExportPrisonerDto>()
                            .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xml = new StringBuilder();
            var writer = new StringWriter(xml);
            using (writer)
            {
                serializer.Serialize(writer, prisoners, namespaces);
            }

            return xml.ToString();
        }
    }
}