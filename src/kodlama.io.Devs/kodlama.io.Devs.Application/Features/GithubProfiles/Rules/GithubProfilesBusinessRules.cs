using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.GithubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        IGithubProfileRepository _githubProfileRepository;

        public GithubProfileBusinessRules(IGithubProfileRepository githubProfileRepository)
        {
            _githubProfileRepository = githubProfileRepository;
        }

        public async Task GithubProfileUrlCanNotBeDuplicatedWhenInserted(string url)
        {
            IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(pl => pl.URL == url);
            if (result.Items.Any()) throw new BusinessException("Github profile name exists.");
        }

        public async Task GithubProfileMustBeExist(GithubProfile githubProfile)
        {
            if (githubProfile is null) throw new BusinessException("Github profile not exist.");
        } 
    }
}
