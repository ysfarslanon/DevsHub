using AutoMapper;
using kodlama.io.Devs.Application.Features.Technologies.Dtos;
using kodlama.io.Devs.Application.Features.Technologies.Rules;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdateTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdateTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology technology = _technologyRepository.Get(t => t.Id == request.Id);

            await _technologyBusinessRules.TechnologyMustBeExist(technology);
            await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(technology.Name);
            await _technologyBusinessRules.IsItRegisteredProgrammingLanguage(technology.ProgrammingLanguageId);

            Technology updatedTechnology = await _technologyRepository.UpdateAsync(technology);
            UpdateTechnologyDto updateTechnologyDto = _mapper.Map<UpdateTechnologyDto>(updatedTechnology);

            return updateTechnologyDto;
        }
    }
}
