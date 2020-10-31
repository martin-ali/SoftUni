namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);
            var validMovies = new List<Movie>();
            var result = new StringBuilder();

            foreach (var movie in movies)
            {
                if (EntityValidator.EntityIsValid(movie)
                && context.Movies.Any(m => m.Title == movie.Title) == false)
                {
                    result.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:0.00}!");
                    validMovies.Add(movie);
                }
                else
                {
                    result.AppendLine("Invalid data!");
                }
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return result.ToString();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDtos = JsonConvert.DeserializeObject<List<ImportHallDto>>(jsonString);
            var validHalls = new List<Hall>();
            var result = new StringBuilder();

            foreach (var hallDto in hallDtos)
            {
                var projectionType = "Normal";
                var hall = Mapper.Map<Hall>(hallDto);

                projectionType = GetProjectionType(projectionType, hall);

                PopulateHallSeats(hall, hallDto.Seats);

                if (EntityValidator.EntityIsValid(hall) && hallDto.Seats > 0)
                {
                    result.AppendLine($"Successfully imported {hall.Name}({projectionType}) with {hallDto.Seats} seats!");
                    validHalls.Add(hall);
                }
                else
                {
                    result.AppendLine("Invalid data!");
                }
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return result.ToString();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<ImportProjectionDto>),
                                                new XmlRootAttribute("Projections"));

            var projections = (List<ImportProjectionDto>)serializer.Deserialize(new StringReader(xmlString));
            var result = new StringBuilder();

            foreach (var projectionDto in projections)
            {
                var projection = Mapper.Map<Projection>(projectionDto);
                if (EntityValidator.EntityIsValid(projection)
                    && context.Movies.Find(projection.MovieId) != null
                    && context.Halls.Find(projection.HallId) != null)
                {
                    context.Projections.Add(projection);
                    result.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
                }
                else
                {
                    result.AppendLine("Invalid data!");
                }
            }

            context.SaveChanges();

            return result.ToString();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCustomerDto>),
                                               new XmlRootAttribute("Customers"));

            var customerDtos = (List<ImportCustomerDto>)serializer.Deserialize(new StringReader(xmlString));
            var result = new StringBuilder();

            foreach (var customerDto in customerDtos)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                if (EntityValidator.EntityIsValid(customer))
                {
                    result.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
                    context.Customers.Add(customer);
                }
                else
                {
                    result.AppendLine("Invalid data!");
                }
            }

            context.SaveChanges();

            return result.ToString();
        }

        private static void PopulateHallSeats(Hall hall, int seats)
        {
            for (int i = 0; i < seats; i++)
            {
                hall.Seats.Add(new Seat());
            }
        }

        private static string GetProjectionType(string projectionType, Hall hall)
        {
            if (hall.Is4Dx && hall.Is3D)
            {
                projectionType = "4Dx/3D";
            }
            else if (hall.Is4Dx)
            {
                projectionType = "4Dx";
            }
            else if (hall.Is3D)
            {
                projectionType = "3D";
            }

            return projectionType;
        }
    }
}