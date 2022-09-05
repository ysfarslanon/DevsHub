using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.CreateProgrammingLanguage;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.DeleteProgrammingLanguage;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commads.UpdateProgrammingLanguage;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);

            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeleteProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdateProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);

            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLaguageGetByIdDto programmingLaguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(programmingLaguageGetByIdDto);
        }
    }
}
