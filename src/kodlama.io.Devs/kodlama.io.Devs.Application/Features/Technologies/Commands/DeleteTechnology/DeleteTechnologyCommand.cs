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

namespace kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeleteTechnologyDto>
    {
        public int Id { get; set; }
    }
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeleteTechnologyDto>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            Technology technology = _technologyRepository.Get(t => t.Id == request.Id);

            _technologyBusinessRules.TechnologyMustBeExist(technology);

            Technology deletedTechnology = await _technologyRepository.DeleteAsync(technology);
            DeleteTechnologyDto deleteTechnologyDto = _mapper.Map<DeleteTechnologyDto>(deletedTechnology);

            return deleteTechnologyDto;
        }
    }
}