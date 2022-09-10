using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Rules;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDeveloperUser
{
    public class CreateDeveloperUserCommand : UserForRegisterDto, IRequest<AccessToken>
    {

    }

    public class CreateDeveloperUserCommandHandler : IRequestHandler<CreateDeveloperUserCommand, AccessToken>
    {
        private readonly IDeveloperUserRepository _developerUserRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly DeveloperUserBusinessRules _developerUserBusinessRules;

        public CreateDeveloperUserCommandHandler(IDeveloperUserRepository developerUserRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperUserBusinessRules developerUserBusinessRules)
        {
            _developerUserRepository = developerUserRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _developerUserBusinessRules = developerUserBusinessRules;
        }

        public async Task<AccessToken> Handle(CreateDeveloperUserCommand request, CancellationToken cancellationToken)
        {
            await _developerUserBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);
                        
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            DeveloperUser developerUser = _mapper.Map<DeveloperUser>(request);
            // special developerUser properties
            developerUser.PasswordHash = passwordHash;
            developerUser.PasswordSalt = passwordSalt;

            await _developerUserRepository.AddAsync(developerUser);
            AccessToken accessToken = _tokenHelper.CreateToken(developerUser, new List<OperationClaim>());

            return accessToken;
        }
    }
}
