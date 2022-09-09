using AutoMapper;
using Core.Persistence.Paging;
using kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using kodlama.io.Devs.Application.Features.Technologies.Dtos;
using kodlama.io.Devs.Application.Features.Technologies.Models;
using kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechology;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, CreateTechnologyDto>().ReverseMap();

            CreateMap<Technology, DeleteTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Technology, UpdateTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, GetByIdTechnologyQuery>().ReverseMap();
            CreateMap<Technology, TechnologyGetByIdDto>()
                .ForMember(c => c.ProgrammigLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>()
                .ForMember(c => c.ProgrammmingLanguage, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();
        }

    }
}
