using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSales.Basic.Application.Features.Categories.Commands.CreateCategory;
using PointOfSales.Basic.Application.Features.Categories.Commands.DeleteCategory;
using PointOfSales.Basic.Application.Features.Categories.Commands.UpdateCategory;
using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Categories.Queries.GetCategoryById;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSales.Basic.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<GetAllCategoriesViewModel>>> Get([FromQuery] GetAllCategoriesParameter filter)
        {

            var response = (await Mediator.Send(new GetAllCategoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber })).Data;

            return response.ToList();
            //return Ok(await Mediator.Send(new GetAllCategoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryByIdCommand { Id = id }));
        }
    }
}
