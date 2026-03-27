using Asp.Versioning;
using Base.Application.DTOs.SoftSkills;
using Base.Application.UseCases.SoftSkills.Commands.Create;
using Base.Application.UseCases.SoftSkills.Commands.Delete;
using Base.Application.UseCases.SoftSkills.Commands.Update;
using Base.Application.UseCases.SoftSkills.Queries.GetById;
using Base.Application.UseCases.SoftSkills.Queries.List;
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
    public class SoftSkillController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateSoftSkillCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateSoftSkillCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSoftSkillCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SoftSkillDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSoftSkillByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("portfolio/{portfolioId:guid}")]
        public async Task<ActionResult<PagedResult<SoftSkillDto>>> ListByPortfolio(Guid portfolioId, [FromQuery] ListSoftSkillsByPortfolioQuery query)
        {
            query.PortfolioId = portfolioId;
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
