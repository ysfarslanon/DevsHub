using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListBrand
{
    public class GetListProgrammingLaguageQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListProgrammingLaguageQueryHandler : IRequestHandler<GetListProgrammingLaguageQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLaguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLaguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguage = await _programmingLanguageRepository
                .GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize);

            ProgrammingLanguageListModel programmingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);


            return programmingLanguageListModel;
        }
    }
}
