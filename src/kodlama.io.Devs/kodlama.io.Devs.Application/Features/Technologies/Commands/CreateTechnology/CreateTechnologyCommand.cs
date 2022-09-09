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

namespace kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreateTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }

    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreateTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<CreateTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
            await _technologyBusinessRules.IsItRegisteredProgrammingLanguage(request.ProgrammingLanguageId);

            Technology mappedTechnology = _mapper.Map<Technology>(request);
            Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
            CreateTechnologyDto createTechnologyDto = _mapper.Map<CreateTechnologyDto>(createdTechnology);

            return createTechnologyDto;
        }
    }
}
