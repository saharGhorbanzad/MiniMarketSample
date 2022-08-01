using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheard;
using Sheard.Command.Product;
using Sheard.Dto.Product;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator mediator;

        public ProductController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("PostProduct")]
        public async Task<IActionResult> Post(InsertProductDto insertProductDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new InsertProductCommand
            {
                ProductName = insertProductDto.ProductName,
                CategoryId = insertProductDto.CategoryId,
                CreateDateTime = insertProductDto.CreateDateTime,
                QuantityPerUnit = insertProductDto.QuantityPerUnit,
                UnitPrice = insertProductDto.UnitPrice,
                UnitsInStock = insertProductDto.UnitsInStock
            }, cancellationToken);

            return Ok(new ApiResult(result));
        }
    }
}
