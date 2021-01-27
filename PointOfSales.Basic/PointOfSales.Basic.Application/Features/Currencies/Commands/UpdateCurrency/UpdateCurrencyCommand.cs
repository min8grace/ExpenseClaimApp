using MediatR;
using PointOfSales.Basic.Application.Exceptions;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Currencies.Commands.UpdateCurrency
{
    public  class UpdateCurrencyCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }


        public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, Response<int>>
        {
            private readonly ICurrencyRepositoryAsync _currencyRepository;
            public UpdateCurrencyCommandHandler(ICurrencyRepositoryAsync currencyRepository)
            {
                _currencyRepository = currencyRepository;
            }
            public async Task<Response<int>> Handle(UpdateCurrencyCommand command, CancellationToken cancellationToken)
            {
                var currency = await _currencyRepository.GetCurrencyById(command.Code);

                if (currency == null)
                {
                    throw new ApiException($"Currency Not Found.");
                }
                else
                {
                    currency.Name = command.Name;
                    currency.Symbol = command.Symbol;
                    await _currencyRepository.UpdateAsync(currency);
                    return new Response<int>(currency.Code);
                }
            }
        }
    }
}
