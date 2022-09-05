using AutoMapper;
using Core.Persistence.Paging;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.CreateProgrammingLanguage;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.DeleteProgrammingLanguage;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.UpdateProgrammingLanguage;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLaguageGetByIdDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
        }
    }
}
