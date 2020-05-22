namespace SoftJail
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ExportDto;
    using SoftJail.DataProcessor.ImportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<ImportPrisonerDto, OfficerPrisoner>()
                .ForMember(p => p.PrisonerId, op => op.MapFrom(d => d.Id))
                .ReverseMap();

            this.CreateMap<ImportOfficerDto, Officer>()
                .ForMember(o => o.Position, op => op.MapFrom(d => (Position)Enum.Parse(typeof(Position), d.Position)))
                .ForMember(o => o.Weapon, op => op.MapFrom(d => (Weapon)Enum.Parse(typeof(Weapon), d.Weapon)))
                // .ForMember(o => o.Position, op => op.MapFrom(d => TryConvertToEnum<Position>(d.Position)))
                // .ForMember(o => o.Weapon, op => op.MapFrom(d => TryConvertToEnum<Weapon>(d.Weapon)))
                // .ForMember(o => o.OfficerPrisoners, op => op.MapFrom(d => d.Prisoners.Select(Mapper.Map<OfficerPrisoner>)))
                .ReverseMap();

            this.CreateMap<Mail, ExportMailDto>()
                .ForMember(d => d.Description, op => op.MapFrom(m => new string(m.Description.Reverse().ToArray())))
                .ReverseMap();

            this.CreateMap<Prisoner, ExportPrisonerDto>()
                .ForMember(p => p.IncarcerationDate, op => op.MapFrom(d => d.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)))
                .ForMember(p => p.EncryptedMessages, op => op.MapFrom(p => p.Mails.Select(m => Mapper.Map<ExportMailDto>(m))))
                .ReverseMap();
        }


    }
}
