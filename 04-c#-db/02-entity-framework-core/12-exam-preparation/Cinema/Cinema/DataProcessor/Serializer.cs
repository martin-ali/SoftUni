namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                            .Where(m => m.Rating >= rating)
                            .Where(m => m.Projections.Any(p => p.Tickets.Count >= 1))
                            .OrderByDescending(m => m.Rating)
                            .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                            .Take(10)
                            .Select(m => new
                            {
                                MovieName = m.Title,
                                Rating = $"{m.Rating:0.00}",
                                TotalIncomes = $"{m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)):0.00}",
                                Customers = m.Projections
                                            .SelectMany(p => p.Tickets
                                                        .Select(t => new
                                                        {
                                                            t.Customer.FirstName,
                                                            t.Customer.LastName,
                                                            Balance = $"{t.Customer.Balance:0.00}"
                                                        }))
                                            .OrderByDescending(c => c.Balance)
                                            .ThenBy(c => c.FirstName)
                                            .ThenBy(c => c.LastName)
                            })
                            .ToList();

            var json = JsonConvert.SerializeObject(movies);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var serializer = new XmlSerializer(typeof(List<ExportCustomerDto>),
                                               new XmlRootAttribute("Customers"));

            var customers = context.Customers
                            .Where(c => c.Age >= age)
                            .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                            .Take(10)
                            .ProjectTo<ExportCustomerDto>()
                            // .OrderByDescending(c => c.SpentMoney)
                            .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xml = new StringBuilder();
            var writer = new StringWriter(xml);
            using (writer)
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return xml.ToString();
        }


    }
}