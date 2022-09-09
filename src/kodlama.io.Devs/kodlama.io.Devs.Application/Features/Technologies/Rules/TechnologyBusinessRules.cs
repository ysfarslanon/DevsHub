using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _technologyRepository = technologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string technologyName)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(pl => pl.Name == technologyName);
            if (result.Items.Any()) throw new BusinessException("Technology name exists.");
        }

        public async Task TechnologyMustBeExist(Technology technology)
        {
            if (technology is null) throw new BusinessException("Technology not exist.");
        }

        public async Task IsItRegisteredProgrammingLanguage(int programmingLanguageId)
        {
            ProgrammingLanguage? result = await _programmingLanguageRepository.GetAsync(t => t.Id == programmingLanguageId);
            if (result is null) throw new BusinessException("Programming language not exist");
        }
    }
}
