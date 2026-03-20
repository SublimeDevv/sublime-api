using Asp.Versioning;
using Base.Application.DTOs.Products;
using Base.Application.UseCases.Products.Commands.Create;
using Base.Application.UseCases.Products.Queries.List;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDetailDto>>> ListProducts([FromQuery] ProductListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}