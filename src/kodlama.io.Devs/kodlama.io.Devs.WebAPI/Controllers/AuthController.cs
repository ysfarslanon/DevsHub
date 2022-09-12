using Core.Security.Entities;
using Core.Security.JWT;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDeveloperUser;
using kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDevelopUser;
using kodlama.io.Devs.Application.Services.Repositories;
using kodlama.io.Devs.Domain.Entities;
using kodlama.io.Devs.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        IUserRepository _user;
        ITokenHelper _tokenHelper;
        IDeveloperUserRepository _developerUserRepository;
        public AuthController(IUserRepository user, ITokenHelper tokenHelper, IDeveloperUserRepository developerUserRepository)
        {
            _user = user;
            _tokenHelper = tokenHelper;
            _developerUserRepository = developerUserRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateDeveloperUserCommand createDeveloperCommand)
        {
            var result = await Mediator.Send(createDeveloperCommand);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDeveloperUserCommand loginDeveloperUserCommand)
        {
            var result = await Mediator.Send(loginDeveloperUserCommand);

            return Ok(result);
        }


    }
}
