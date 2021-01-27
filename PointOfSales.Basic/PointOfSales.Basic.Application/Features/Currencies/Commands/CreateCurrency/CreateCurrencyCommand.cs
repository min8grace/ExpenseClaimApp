using AutoMapper;
using MediatR;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
    public class CreateCurrencyCommanddHandler : IRequestHandler<CreateCurrencyCommand, Response<int>>
    {
        private readonly ICurrencyRepositoryAsync _currencyRepository;
        private readonly IMapper _mapper;
        public CreateCurrencyCommanddHandler(ICurrencyRepositoryAsync currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = _mapper.Map<Currency>(request);
            await _currencyRepository.AddAsync(currency);
            return new Response<int>(currency.Code);
        }
    }
}
