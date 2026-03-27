using Asp.Versioning;
using Base.Application.DTOs.Projects;
using Base.Application.UseCases.Projects.Commands.Create;
using Base.Application.UseCases.Projects.Commands.Delete;
using Base.Application.UseCases.Projects.Commands.Update;
using Base.Application.UseCases.Projects.Queries.GetById;
using Base.Application.UseCases.Projects.Queries.List;
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
    public class ProjectController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProjectCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProjectCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("portfolio/{portfolioId:guid}")]
        public async Task<ActionResult<PagedResult<ProjectDto>>> ListByPortfolio(Guid portfolioId, [FromQuery] ListProjectsByPortfolioQuery query)
        {
            query.PortfolioId = portfolioId;
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
