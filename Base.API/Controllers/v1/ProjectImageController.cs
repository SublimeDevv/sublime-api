using Asp.Versioning;
using Base.Application.DTOs.ProjectImages;
using Base.Application.UseCases.ProjectImages.Commands.Create;
using Base.Application.UseCases.ProjectImages.Commands.Delete;
using Base.Application.UseCases.ProjectImages.Commands.Update;
using Base.Application.UseCases.ProjectImages.Queries.GetById;
using Base.Application.UseCases.ProjectImages.Queries.List;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class ProjectImageController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectImageCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProjectImageCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProjectImageCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectImageDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProjectImageByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("project/{projectId:guid}")]
        public async Task<ActionResult<List<ProjectImageDto>>> ListByProject(Guid projectId)
        {
            var result = await _mediator.Send(new ListProjectImagesByProjectQuery { ProjectId = projectId });
            return Ok(result);
        }
    }
}
