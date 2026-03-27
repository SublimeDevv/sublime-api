using Asp.Versioning;
using Base.Application.DTOs.WorkExperiences;
using Base.Application.UseCases.WorkExperiences.Commands.Create;
using Base.Application.UseCases.WorkExperiences.Commands.Delete;
using Base.Application.UseCases.WorkExperiences.Commands.Update;
using Base.Application.UseCases.WorkExperiences.Queries.GetById;
using Base.Application.UseCases.WorkExperiences.Queries.List;
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
    public class WorkExperienceController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkExperienceCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateWorkExperienceCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteWorkExperienceCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<WorkExperienceDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetWorkExperienceByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("portfolio/{portfolioId:guid}")]
        public async Task<ActionResult<PagedResult<WorkExperienceDto>>> ListByPortfolio(Guid portfolioId, [FromQuery] ListWorkExperiencesByPortfolioQuery query)
        {
            query.PortfolioId = portfolioId;
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
