using Asp.Versioning;
using Base.Application.DTOs.Technologies;
using Base.Application.UseCases.Technologies.Commands.Create;
using Base.Application.UseCases.Technologies.Commands.Delete;
using Base.Application.UseCases.Technologies.Commands.Update;
using Base.Application.UseCases.Technologies.Queries.GetById;
using Base.Application.UseCases.Technologies.Queries.List;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class TechnologyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateTechnologyCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateTechnologyCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTechnologyCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TechnologyDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTechnologyByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<TechnologyDto>>> List([FromQuery] ListTechnologiesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
