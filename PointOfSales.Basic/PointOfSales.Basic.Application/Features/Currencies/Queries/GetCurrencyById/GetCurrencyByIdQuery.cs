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

namespace PointOfSales.Basic.Application.Features.Currencies.Queries.GetCurrencyById
{
    public class GetCurrencyByIdQuery : IRequest<Response<Currency>>
    {
        public int Id { get; set; }
        public class GetCurrencyByIdQueryHandler : IRequestHandler<GetCurrencyByIdQuery, Response<Currency>>
        {
            private readonly ICurrencyRepositoryAsync _currencyRepository;
            public GetCurrencyByIdQueryHandler(ICurrencyRepositoryAsync currencyRepository)
            {
                _currencyRepository = currencyRepository;
            }
            public async Task<Response<Currency>> Handle(GetCurrencyByIdQuery query, CancellationToken cancellationToken)
            {
                //var currency = await _currencyRepository.GetByIdAsync(query.Id);
                var currency = await _currencyRepository.GetByIdAsync(query.Id);

                if (currency == null) throw new ApiException($"Currency Not Found.");
                return new Response<Currency>(currency);
            }
        }
    }
}
