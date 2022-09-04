using AutoMapper;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateProgrammingLanguageCommandHandler 
        : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public UpdateProgrammingLanguageCommandHandler
            (IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.ProgrammingLanguageMustBeExist(request.Id);
            await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
            //I used var instead of "ProgammingLanguage" because it became too long with the entity name and degrading readability
            var selectedEntity = _mapper.Map<ProgrammingLanguage>(request);
            var updatedEntity = await _programmingLanguageRepository.UpdateAsync(selectedEntity);
            // special properties of Programming Language entity

            UpdateProgrammingLanguageDto returnEntity = _mapper.Map<UpdateProgrammingLanguageDto>(updatedEntity);

            return returnEntity;
        }
    }

}
