using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim;
using PointOfSales.Basic.Application.Features.Claims.Commands.DeleteClaimById;
using PointOfSales.Basic.Application.Features.Claims.Commands.UpdateClaim;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetClaimById;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetClaimsBySearch;
using PointOfSales.Basic.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace PointOfSales.Basic.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class ClaimController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<GetAllClaimsViewModel>>> Get([FromQuery] GetAllClaimsParameter filter)
        {

            var response = (await Mediator.Send(new GetAllClaimsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber })).Data;

            return response.ToList();
            //return Ok(await Mediator.Send(new GetAllClaimsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        //GET api/<controller>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Claim>> Get(int id)
        {
            Claim response = (await Mediator.Send(new GetClaimByIdQuery { Id = id })).Data;
            return response;
        }

        // GET api/<controller>/5
        [HttpGet("{searchStr}")]
        public async Task<ActionResult<List<GetAllClaimsViewModel>>> GetBySearchString(string searchStr)
        {
            return Ok(await Mediator.Send(new GetClaimsBySearchQuery { searchStr = searchStr }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Claim>> Post(CreateClaimCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut()]
        [Authorize]
        public async Task<ActionResult<Claim>> Put(UpdateClaimCommand command)
        {            
            if ((command.Id) == 0)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<Claim>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClaimByIdCommand { Id = id }));
        }
    }
}
