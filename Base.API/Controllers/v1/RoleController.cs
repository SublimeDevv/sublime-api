using Asp.Versioning;
using Base.Application.UseCases.Auth.Commands.AssignRole;
using Base.Application.UseCases.Auth.Commands.CreateRole;
using Base.Application.UseCases.Auth.Commands.DeleteRole;
using Base.Application.UseCases.Auth.Commands.RemoveRole;
using Base.Application.UseCases.Auth.Queries.GetRoles;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class RoleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IList<string>>> GetRoles()
        {
            var roles = await _mediator.Send(new GetRolesQuery());
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRole([FromBody] RemoveRoleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            await _mediator.Send(new DeleteRoleCommand { RoleName = roleName });
            return NoContent();
        }
    }
}
