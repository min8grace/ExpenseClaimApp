using AutoMapper;
using MediatR;
using PointOfSales.Basic.Application.Exceptions;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Currencies.Commands.DeleteCurrency
{
    public class DeleteCurrencyByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCurrencyByIdCommandHandler : IRequestHandler<DeleteCurrencyByIdCommand, Response<int>>
        {
            private readonly ICurrencyRepositoryAsync _currencyRepository;
            public DeleteCurrencyByIdCommandHandler(ICurrencyRepositoryAsync currencyRepository)
            {
                _currencyRepository = currencyRepository;
            }
            public async Task<Response<int>> Handle(DeleteCurrencyByIdCommand command, CancellationToken cancellationToken)
            {
                var currency = await _currencyRepository.GetByIdAsync(command.Id);
                if (currency == null) throw new ApiException($"Currency Not Found.");
                await _currencyRepository.DeleteAsync(currency);
                return new Response<int>(currency.Code);
            }
        }
    }
}
