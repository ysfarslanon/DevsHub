using kodlama.io.Devs.Application.Features.Technologies.Models;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Requests;
using kodlama.io.Devs.Application.Services.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Core.Persistence.Paging;
using kodlama.io.Devs.Domain.Entities;

namespace kodlama.io.Devs.Application.Features.Technologies.Queries.GeListTechnologyByDynamic
{
    public class GetListTechnologyByDyanmicQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }

    public class GetListTechnologyByDyanmicQueryHandler : IRequestHandler<GetListTechnologyByDyanmicQuery, TechnologyListModel>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetListTechnologyByDyanmicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<TechnologyListModel> Handle(GetListTechnologyByDyanmicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> tecnologies = await _technologyRepository
                .GetListByDynamicAsync(index: request.PageRequest.Page,
                                      size: request.PageRequest.PageSize,
                                      dynamic: request.Dynamic,
                                      include: i => i.Include(i => i.ProgrammingLanguage)
                                      );

            TechnologyListModel mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(tecnologies);
           
            return mappedTechnologyListModel;
        }
    }
}
