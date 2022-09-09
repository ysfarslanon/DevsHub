using Core.Application.Requests;
using Core.Persistence.Dynamic;
using kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using kodlama.io.Devs.Application.Features.Technologies.Dtos;
using kodlama.io.Devs.Application.Features.Technologies.Models;
using kodlama.io.Devs.Application.Features.Technologies.Queries.GeListTechnologyByDynamic;
using kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechology;
using kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreateTechnologyDto createTechnologyDto = await Mediator.Send(createTechnologyCommand);
            return Created("", createTechnologyDto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeleteTechnologyDto deleteTechnologyDto = await Mediator.Send(deleteTechnologyCommand);

            return Ok(deleteTechnologyDto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdateTechnologyDto updateTechnologyDto = await Mediator.Send(updateTechnologyCommand);

            return Ok(updateTechnologyDto);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }

        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery query = new() { PageRequest = pageRequest };
            TechnologyListModel model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpPost("dynamic")]
        public async Task<ActionResult> GetListByDyanmic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dyanamic)
        {
            GetListTechnologyByDyanmicQuery query = new() { PageRequest = pageRequest, Dynamic = dyanamic };
            TechnologyListModel model = await Mediator.Send(query);
            return Ok(model);
        }
    }
}
