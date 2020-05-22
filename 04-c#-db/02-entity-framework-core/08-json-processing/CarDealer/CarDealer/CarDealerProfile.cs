using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.Dtos;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Makes 13. Import Sales not work
            this.CreateMap<CarImportDto, Car>()
                .ForMember(c => c.PartCars,
                            o => o.MapFrom(cid => cid.PartCars
                                                        .Distinct()
                                                        .Select(pc => new PartCar { PartId = pc })))
                .ReverseMap();
        }
    }
}
