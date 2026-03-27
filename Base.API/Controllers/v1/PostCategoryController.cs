using Asp.Versioning;
using Base.Application.UseCases.PostCategories.Commands.Assign;
using Base.Application.UseCases.PostCategories.Commands.Remove;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class PostCategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Assign(AssignPostCategoryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemovePostCategoryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
