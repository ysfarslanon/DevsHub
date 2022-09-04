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

namespace kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }
    }

    public class DeleteProgrammingLanguageCommandHandler 
        : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageRules;

        public DeleteProgrammingLanguageCommandHandler
            (IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _programmingLanguageRules = programmingLanguageRules;
        }

        public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            // rules
            ProgrammingLanguage? selectedEntity = await _programmingLanguageRepository.GetAsync(e => e.Id == request.Id);

            await _programmingLanguageRepository.DeleteAsync(selectedEntity);
            DeleteProgrammingLanguageDto deleteProgrammingLanguageDto = _mapper.Map<DeleteProgrammingLanguageDto>(selectedEntity);

            return deleteProgrammingLanguageDto;
        }
    }
}
