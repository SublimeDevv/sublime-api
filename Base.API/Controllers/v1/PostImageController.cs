using Asp.Versioning;
using Base.Application.DTOs.PostImages;
using Base.Application.UseCases.PostImages.Commands.Create;
using Base.Application.UseCases.PostImages.Commands.Delete;
using Base.Application.UseCases.PostImages.Commands.Update;
using Base.Application.UseCases.PostImages.Queries.GetById;
using Base.Application.UseCases.PostImages.Queries.List;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class PostImageController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostImageCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdatePostImageCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePostImageCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PostImageDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPostImageByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("post/{postId:guid}")]
        public async Task<ActionResult<List<PostImageDto>>> ListByPost(Guid postId)
        {
            var result = await _mediator.Send(new ListPostImagesByPostQuery { PostId = postId });
            return Ok(result);
        }
    }
}
