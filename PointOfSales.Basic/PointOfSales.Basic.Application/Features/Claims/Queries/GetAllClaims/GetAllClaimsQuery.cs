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

namespace PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims
{
    public class GetAllLineItemsQuery : IRequest<PagedResponse<IEnumerable<GetAllLineItemsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllClaimsQueryHandler : IRequestHandler<GetAllLineItemsQuery, PagedResponse<IEnumerable<GetAllLineItemsViewModel>>>
    {
        private readonly IClaimRepositoryAsync _claimRepository;
        private readonly IMapper _mapper;
        public GetAllClaimsQueryHandler(IClaimRepositoryAsync claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllLineItemsViewModel>>> Handle(GetAllLineItemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllClaimsParameter>(request);
            var claim = await _claimRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var claimViewModel = _mapper.Map<IEnumerable<GetAllLineItemsViewModel>>(claim);
            return new PagedResponse<IEnumerable<GetAllLineItemsViewModel>>(claimViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
