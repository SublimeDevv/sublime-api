using Asp.Versioning;
using Base.Application.DTOs.SocialsMedia;
using Base.Application.UseCases.SocialsMedia.Commands.Create;
using Base.Application.UseCases.SocialsMedia.Commands.Delete;
using Base.Application.UseCases.SocialsMedia.Commands.Update;
using Base.Application.UseCases.SocialsMedia.Queries.GetById;
using Base.Application.UseCases.SocialsMedia.Queries.List;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class SocialMediaController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateSocialMediaCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSocialMediaCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SocialMediaDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSocialMediaByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("portfolio/{portfolioId:guid}")]
        public async Task<ActionResult<List<SocialMediaDto>>> ListByPortfolio(Guid portfolioId)
        {
            var result = await _mediator.Send(new ListSocialsMediaByPortfolioQuery { PortfolioId = portfolioId });
            return Ok(result);
        }
    }
}
