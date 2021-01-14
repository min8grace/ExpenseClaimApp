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
    public class GetAllClaimsQuery : IRequest<PagedResponse<IEnumerable<GetAllClaimsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllClaimsQueryHandler : IRequestHandler<GetAllClaimsQuery, PagedResponse<IEnumerable<GetAllClaimsViewModel>>>
    {
        private readonly IClaimRepositoryAsync _claimRepository;
        private readonly IMapper _mapper;
        public GetAllClaimsQueryHandler(IClaimRepositoryAsync claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllClaimsViewModel>>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllClaimsParameter>(request);
            var claim = await _claimRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var claimViewModel = _mapper.Map<IEnumerable<GetAllClaimsViewModel>>(claim);
            return new PagedResponse<IEnumerable<GetAllClaimsViewModel>>(claimViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
