namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string InvalidData = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departments = JsonConvert.DeserializeObject<List<Department>>(jsonString);
            var result = new StringBuilder();

            foreach (var department in departments)
            {
                var importResult = InvalidData;
                if (EntityValidator.EntityIsValid(department) && department.Cells.All(c => EntityValidator.EntityIsValid(c)))
                {
                    context.Departments.Add(department);

                    importResult = $"Imported {department.Name} with {department.Cells.Count} cells";
                }

                result.AppendLine(importResult);
            }

            context.SaveChanges();
            return result.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisoners = JsonConvert.DeserializeObject<List<Prisoner>>(
                    jsonString,
                    new IsoDateTimeConverter
                    {
                        DateTimeFormat = "dd/MM/yyyy"
                    }
                );
            var result = new StringBuilder();

            foreach (var prisoner in prisoners)
            {
                var importResult = InvalidData;
                if (EntityValidator.EntityIsValid(prisoner)
                    && prisoner.Mails.All(m => EntityValidator.EntityIsValid(m)))
                {
                    context.Prisoners.Add(prisoner);

                    importResult = $"Imported {prisoner.FullName} {prisoner.Age} years old";
                }

                result.AppendLine(importResult);
            }

            context.SaveChanges();
            return result.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<ImportOfficerDto>),
                                                 new XmlRootAttribute("Officers"));

            var officers = (List<ImportOfficerDto>)serializer.Deserialize(new StringReader(xmlString));
            var result = new StringBuilder();

            foreach (var officerDto in officers)
            {
                var importResult = InvalidData;

                if (EntityValidator.EntityIsValid(officerDto)
                    && TryConvertToEnum<Position>(officerDto.Position)
                    && TryConvertToEnum<Weapon>(officerDto.Weapon))
                {
                    var officer = Mapper.Map<Officer>(officerDto);

                    if (EntityValidator.EntityIsValid(officer))
                    {
                        context.Officers.Add(officer);
                        officer.OfficerPrisoners = officerDto.Prisoners
                                                    // .Select(p => new OfficerPrisoner { PrisonerId = p.Id })
                                                    .Select(Mapper.Map<OfficerPrisoner>)
                                                    .ToList();

                        importResult = $"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)";
                    }
                }

                result.AppendLine(importResult);
            }

            context.SaveChanges();

            return result.ToString();
        }

        public static bool TryConvertToEnum<T>(string input)
        {
            return Enum.TryParse(typeof(T), input, false, out object result);
        }
    }
}