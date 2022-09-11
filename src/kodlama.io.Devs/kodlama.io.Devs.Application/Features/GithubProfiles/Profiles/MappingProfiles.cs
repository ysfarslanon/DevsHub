using AutoMapper;
using kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();
            CreateMap<GithubProfile, CreateGithubProfileDto>().ReverseMap();

        }
    }
}
