using AutoMapper;
using MediatR;
using PointOfSales.Basic.Application.Exceptions;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Claims.Queries.GetClaimsBySearch
{
    public class GetClaimsBySearchQuery : IRequest<Response<IEnumerable<GetAllClaimsViewModel>>>
    {
        public string searchStr { get; set; }

        public class GetClaimsBySearchQueryHandler : IRequestHandler<GetClaimsBySearchQuery, Response<IEnumerable<GetAllClaimsViewModel>>>
        {
            private readonly IClaimRepositoryAsync _claimRepository;
            private readonly IMapper _mapper;
            public GetClaimsBySearchQueryHandler(IClaimRepositoryAsync claimRepository, IMapper mapper)
            {
                _claimRepository = claimRepository;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<GetAllClaimsViewModel>>> Handle(GetClaimsBySearchQuery request, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetClaimsBySearch(request.searchStr);
                var claimViewModel = _mapper.Map<IEnumerable<GetAllClaimsViewModel>>(claim);
                if (claimViewModel == null) throw new ApiException($"Claim Not Found.");
                return new Response<IEnumerable<GetAllClaimsViewModel>>(claimViewModel);

            }
        }
    }

}
