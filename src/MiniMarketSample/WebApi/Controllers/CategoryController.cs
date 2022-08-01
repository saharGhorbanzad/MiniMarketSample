using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheard;
using Sheard.Command.Category;
using Sheard.Dto.Category;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMediator mediator;
        public CategoryController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("PostCategory")]
        public async Task<ActionResult> Post(InsertCategoryDto insertCategoryDto, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new InsertCategoryCommand
            {
                CategoryName = insertCategoryDto.CategoryName,
                Description = insertCategoryDto.Description,
                Picture = insertCategoryDto.Picture
            }, cancellationToken);

            return Ok(new ApiResult(result));
        }
    }
}
