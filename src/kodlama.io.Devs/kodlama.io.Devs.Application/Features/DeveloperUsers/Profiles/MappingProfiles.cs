using AutoMapper;
using Core.Security.Entities;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDeveloperUser;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDevelopUser;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.DeveloperUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DeveloperUser, CreateDeveloperUserCommand>().ReverseMap();
            CreateMap<User, LoginDeveloperUserCommand>().ReverseMap();
            
        }
    }
}
