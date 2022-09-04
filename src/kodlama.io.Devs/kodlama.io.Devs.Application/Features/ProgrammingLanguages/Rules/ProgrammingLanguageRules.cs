using Core.Persistence.Paging;
using Core.CrossCuttingConcerns.Exceptions;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }

        public async Task ProgrammingLanguageMustBeExist(int id)
        {
            ProgrammingLanguage? result = await _programmingLanguageRepository.GetAsync(e => e.Id == id);
            if (result is null) throw new BusinessException("Programming language not exist.");
        }
       
    }
}
