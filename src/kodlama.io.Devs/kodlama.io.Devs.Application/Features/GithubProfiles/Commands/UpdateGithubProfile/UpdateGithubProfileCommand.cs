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

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommand : IRequest<UpdateGithubProfileDto>
    {
        public int DeveloperUserId { get; set; }
        public string URL { get; set; }
    }

    public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdateGithubProfileDto>
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly IMapper _mapper;
        private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

        public UpdateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
        {
            _githubProfileRepository = githubProfileRepository;
            _mapper = mapper;
            _githubProfileBusinessRules = githubProfileBusinessRules;
        }

        public async Task<UpdateGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
        {
            await _githubProfileBusinessRules.GithubProfileUrlCanNotBeDuplicatedWhenInserted(request.URL);

            GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);
            GithubProfile updatedGithubProfile = await _githubProfileRepository.UpdateAsync(githubProfile);
            UpdateGithubProfileDto updateGithubProfileDto = _mapper.Map<UpdateGithubProfileDto>(updatedGithubProfile);

            return updateGithubProfileDto;
        }
    }
}