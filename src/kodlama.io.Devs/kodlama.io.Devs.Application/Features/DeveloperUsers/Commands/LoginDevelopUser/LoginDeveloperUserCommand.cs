using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Rules;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDevelopUser
{
    public class LoginDeveloperUserCommand : UserForLoginDto, IRequest<AccessToken>
    {

    }
    public class LoginDeveloperUserCommandHandler : IRequestHandler<LoginDeveloperUserCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly DeveloperUserBusinessRules _developerUserBusinessRules;


        public LoginDeveloperUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperUserBusinessRules developerUserBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _developerUserBusinessRules = developerUserBusinessRules;
        }

        public async Task<AccessToken> Handle(LoginDeveloperUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetAsync(
                p => p.Email.ToLower() == request.Email.ToLower(),
                include: i => i.Include(a => a.UserOperationClaims).ThenInclude(b => b.OperationClaim)
                );

            await _developerUserBusinessRules.UserMustExist(user);
            await _developerUserBusinessRules.UserLoginEMailCheck(request.Email);
            await _developerUserBusinessRules.IsVerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

                            
            List<OperationClaim> operationClaims = new List<OperationClaim>() {};

            foreach (var operationClaim in user.UserOperationClaims)
            {
                operationClaims.Add(operationClaim.OperationClaim);
            }

            AccessToken access = _tokenHelper.CreateToken(user, operationClaims);

            return access;
        }
    }
}
