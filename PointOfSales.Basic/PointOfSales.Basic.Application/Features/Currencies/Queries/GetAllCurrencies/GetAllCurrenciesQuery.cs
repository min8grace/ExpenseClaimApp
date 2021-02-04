using AutoMapper;
using MediatR;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCurrencies
{
    public class GetAllCurrenciesQuery : IRequest<PagedResponse<IEnumerable<GetAllCurrenciesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, PagedResponse<IEnumerable<GetAllCurrenciesViewModel>>>
    {
        private readonly ICurrencyRepositoryAsync _currencyRepository;
        private readonly IMapper _mapper;
        public GetAllCurrenciesQueryHandler(ICurrencyRepositoryAsync currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCurrenciesViewModel>>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCurrenciesParameter>(request);
            var currency = await _currencyRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var currencyViewModel = _mapper.Map<IEnumerable<GetAllCurrenciesViewModel>>(currency);
            return new PagedResponse<IEnumerable<GetAllCurrenciesViewModel>>(currencyViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
