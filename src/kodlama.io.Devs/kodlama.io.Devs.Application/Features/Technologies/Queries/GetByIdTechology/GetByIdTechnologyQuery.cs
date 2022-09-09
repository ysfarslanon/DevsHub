using AutoMapper;
using kodlama.io.Devs.Application.Features.Technologies.Dtos;
using kodlama.io.Devs.Application.Features.Technologies.Rules;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechology
{
    public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }
    }
    class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyRules;

        public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyRules = technologyRules;
        }

        public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
        {
            Technology? technology = await _technologyRepository
                .GetAsync(t => t.Id == request.Id,
                          include: i => i.Include(t => t.ProgrammingLanguage)
                          );

            await _technologyRules.TechnologyMustBeExist(technology);

            TechnologyGetByIdDto technologyListDto = _mapper.Map<TechnologyGetByIdDto>(technology);

            return technologyListDto;
        }
    }
}
