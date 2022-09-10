using kodlama.io.Devs.Application.Features.DeveloperUsers.Commands.LoginDeveloperUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateDeveloperUserCommand createDeveloperCommand)
        {
            var result = await Mediator.Send(createDeveloperCommand);

            return Ok(result);
        }


    }
}
