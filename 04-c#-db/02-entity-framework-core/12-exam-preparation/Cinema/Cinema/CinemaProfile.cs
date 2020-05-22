using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Cinema.Data.Models;
using Cinema.DataProcessor.ExportDto;
using Cinema.DataProcessor.ImportDto;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<ImportHallDto, Hall>()
                .ForMember(h => h.Seats, o => o.Ignore())
                .ReverseMap();

            this.CreateMap<ImportProjectionDto, Projection>()
                .ForMember(p => p.DateTime, o => o.MapFrom(d => DateTime.ParseExact(d.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)))
                .ReverseMap();

            this.CreateMap<ImportCustomerDto, Customer>()
                .ReverseMap();

            this.CreateMap<ImportTicketDto, Ticket>()
                .ReverseMap();

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.SpentMoney, o => o.MapFrom(c => $"{c.Tickets.Sum(t => t.Price):00.00}"))
                // .ForMember(d => d.SpentTime, o => o.MapFrom(c => (new TimeSpan(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks)).ToString("hh:mm:ss", CultureInfo.InvariantCulture))))
                .ForMember(d => d.SpentTime, o => o.MapFrom(c => new TimeSpan(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks))))
                .ReverseMap();
        }
    }
}
