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

namespace kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLaguageGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdProgrammingLanguageQueryHandler 
        : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLaguageGetByIdDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public GetByIdProgrammingLanguageQueryHandler
            (IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLaguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);
            
            await _programmingLanguageBusinessRules.ProgrammingLanguageMustBeExist(programmingLanguage.Id);

            ProgrammingLaguageGetByIdDto programmingLaguageGetByIdDto = _mapper.Map<ProgrammingLaguageGetByIdDto>(programmingLanguage);
            return programmingLaguageGetByIdDto;
        }
    }
}
