using AutoMapper;
using kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class CreateGithubProfileCommand : IRequest<CreateGithubProfileDto>
    {
        public int DeveloperUserId { get; set; }
        public string URL { get; set; }
    }

    public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreateGithubProfileDto>
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly IMapper _mapper;
        private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

        public CreateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
        {
            _githubProfileRepository = githubProfileRepository;
            _mapper = mapper;
            _githubProfileBusinessRules = githubProfileBusinessRules;
        }

        public async Task<CreateGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
        {
            await _githubProfileBusinessRules.GithubProfileUrlCanNotBeDuplicatedWhenInserted(request.URL);

            GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);
            GithubProfile createdGithubProfile = await _githubProfileRepository.AddAsync(githubProfile);
            CreateGithubProfileDto createGithubProfileDto = _mapper.Map<CreateGithubProfileDto>(createdGithubProfile);

            return createGithubProfileDto;
        }
    }

}
