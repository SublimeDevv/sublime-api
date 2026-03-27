using Asp.Versioning;
using Base.Application.UseCases.PostTechnologies.Commands.Assign;
using Base.Application.UseCases.PostTechnologies.Commands.Remove;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class PostTechnologyController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Assign(AssignPostTechnologyCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemovePostTechnologyCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
