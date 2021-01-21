using AutoMapper;
using MediatR;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems
{
    public class GetAllLineItemsQuery : IRequest<PagedResponse<IEnumerable<GetAllLineItemsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllLineItemsQueryHandler : IRequestHandler<GetAllLineItemsQuery, PagedResponse<IEnumerable<GetAllLineItemsViewModel>>>
    {
        private readonly IClaimRepositoryAsync _lineItemRepository;
        private readonly IMapper _mapper;
        public GetAllLineItemsQueryHandler(IClaimRepositoryAsync lineItemRepository, IMapper mapper)
        {
            _lineItemRepository = lineItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllLineItemsViewModel>>> Handle(GetAllLineItemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllLineItemsParameter>(request);
            var lineItem = await _lineItemRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var lineItemViewModel = _mapper.Map<IEnumerable<GetAllLineItemsViewModel>>(lineItem);
            return new PagedResponse<IEnumerable<GetAllLineItemsViewModel>>(lineItemViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
