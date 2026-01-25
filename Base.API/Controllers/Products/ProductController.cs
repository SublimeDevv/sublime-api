using Base.Application.UseCases.Products.Commands.Create;
using Base.Application.UseCases.Products.Queries.GetProduct;
using Base.Application.UseCases.Products.Queries.List;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IMediator mediator): ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command) 
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProductDetailDTO>>> ListProducts([FromQuery] ProductListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}