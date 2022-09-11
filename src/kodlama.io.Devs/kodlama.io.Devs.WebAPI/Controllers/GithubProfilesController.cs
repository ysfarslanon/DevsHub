using kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfilesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateGithubProfileCommand createGithubProfileCommand)
        {
            CreateGithubProfileDto createGithubProfileDto= await Mediator.Send(createGithubProfileCommand);
            return Created("", createGithubProfileDto);
        }
    }
}
