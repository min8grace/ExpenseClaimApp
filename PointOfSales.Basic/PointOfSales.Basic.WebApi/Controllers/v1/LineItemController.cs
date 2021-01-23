using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSales.Basic.Application.Features.Claims.Commands;
using PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim;
using PointOfSales.Basic.Application.Features.Claims.Commands.DeleteClaimById;
using PointOfSales.Basic.Application.Features.Claims.Commands.UpdateClaim;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetClaimById;
using PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems;
using PointOfSales.Basic.Application.Features.LineItems.Queries.GetLineItemById;
using PointOfSales.Basic.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointOfSales.Basic.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class LineItemController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<GetAllLineItemsViewModel>>> Get([FromQuery] GetAllLineItemsParameter filter)
        {

            var response = (await Mediator.Send(new GetAllLineItemsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber })).Data;

            return response.ToList();
            //return Ok(await Mediator.Send(new GetAllLineItemsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetLineItemByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateLineItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateLineItemCommand command)
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
            return Ok(await Mediator.Send(new DeleteLineItemByIdCommand { Id = id }));
        }
    }
}
