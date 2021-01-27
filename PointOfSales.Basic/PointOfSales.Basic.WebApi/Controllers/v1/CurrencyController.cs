using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSales.Basic.Application.Features.Currencies.Commands.CreateCurrency;
using PointOfSales.Basic.Application.Features.Currencies.Commands.DeleteCurrency;
using PointOfSales.Basic.Application.Features.Currencies.Commands.UpdateCurrency;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCurrencies;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetCurrencyById;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSales.Basic.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class CurrencyController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<GetAllCurrenciesViewModel>>> Get([FromQuery] GetAllCurrenciesParameter filter)
        {

            var response = (await Mediator.Send(new GetAllCurrenciesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber })).Data;

            return response.ToList();
            //return Ok(await Mediator.Send(new GetAllCurrenciesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCurrencyByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateCurrencyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string code, UpdateCurrencyCommand command)
        {
            if (code != command.Code)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int code)
        {
            return Ok(await Mediator.Send(new DeleteCurrencyByIdCommand { Id = code }));
        }
    }
}
