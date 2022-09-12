using kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
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
        public async Task<IActionResult> Add([FromBody] CreateGithubProfileCommand createGithubProfileCommand)
        {
            CreateGithubProfileDto createGithubProfileDto= await Mediator.Send(createGithubProfileCommand);

            return Created("", createGithubProfileDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
        {
            UpdateGithubProfileDto updateGithubProfileDto = await Mediator.Send(updateGithubProfileCommand);

            return Ok(updateGithubProfileDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubProfileCommand deleteGithubProfileCommand)
        {
            DeleteGithubProfileDto deleteGithubProfileDto = await Mediator.Send(deleteGithubProfileCommand);

            return Ok(deleteGithubProfileDto);
        }
    }
}
