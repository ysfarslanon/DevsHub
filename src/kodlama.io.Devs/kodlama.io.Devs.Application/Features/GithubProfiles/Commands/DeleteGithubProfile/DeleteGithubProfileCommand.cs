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

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public  class DeleteGithubProfileCommand : IRequest<DeleteGithubProfileDto>
    {
        public int Id { get; set; }
    }

    public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeleteGithubProfileDto>
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly IMapper _mapper;
        private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

        public DeleteGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
        {
            _githubProfileRepository = githubProfileRepository;
            _mapper = mapper;
            _githubProfileBusinessRules = githubProfileBusinessRules;
        }

        public async Task<DeleteGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
        {
            GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);

            await _githubProfileBusinessRules.GithubProfileMustBeExist(githubProfile);

            GithubProfile deletedGithubProfile = await _githubProfileRepository.DeleteAsync(githubProfile);
            DeleteGithubProfileDto deleteGithubProfileDto = _mapper.Map<DeleteGithubProfileDto>(deletedGithubProfile);

            return deleteGithubProfileDto;
        }
    }
}
