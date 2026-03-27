using Asp.Versioning;
using Base.Application.DTOs.Portfolios;
using Base.Application.UseCases.Portfolios.Commands.Create;
using Base.Application.UseCases.Portfolios.Commands.Delete;
using Base.Application.UseCases.Portfolios.Commands.Update;
using Base.Application.UseCases.Portfolios.Queries.GetById;
using Base.Application.UseCases.Portfolios.Queries.List;
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
    public class PortfolioController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreatePortfolioCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdatePortfolioCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePortfolioCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PortfolioDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPortfolioByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PortfolioDto>>> List([FromQuery] ListPortfoliosQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
