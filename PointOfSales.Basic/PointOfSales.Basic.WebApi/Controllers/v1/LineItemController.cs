using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Commands.DeleteLineItemyId;
using PointOfSales.Basic.Application.Features.LineItems.Commands.UpdateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems;
using PointOfSales.Basic.Application.Features.LineItems.Queries.GetLineItemById;
using PointOfSales.Basic.Application.Filters;
using PointOfSales.Basic.Domain.Entities;
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LineItem>> Get(int id)
        {
            var response = (await Mediator.Send(new GetLineItemByIdQuery { Id = id })).Data;
            return response;
        }

        // GET api/<controller>/5
        //[HttpGet("{searchStr}")]
        //public async Task<ActionResult<List<GetAllClaimsViewModel>>> GetBySearchString(string searchStr)
        //{
        //    return Ok(await Mediator.Send(new GetClaimsBySearchQuery { searchStr = searchStr }));
        //}


        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LineItem>> Post(CreateLineItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut()]
        [Authorize]
        public async Task<ActionResult<LineItem>> Put(UpdateLineItemCommand command)
        {
            //if (id != command.Id)
            //{
            //    return BadRequest();
            //}
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<LineItem>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteLineItemByIdCommand { Id = id }));
        }
    }
}
