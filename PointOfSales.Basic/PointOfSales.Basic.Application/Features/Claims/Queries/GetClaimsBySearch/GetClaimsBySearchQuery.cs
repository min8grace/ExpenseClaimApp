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
        public int Id { get; set; }
        public string searchString { get; set; }

       
        public class GetClaimsBySearchQueryHandler : IRequestHandler<GetClaimsBySearchQuery, Response<IEnumerable<GetAllClaimsViewModel>>>
        {
            private readonly IClaimRepositoryAsync _claimRepository;
            private readonly IMapper _mapper;
            public GetClaimsBySearchQueryHandler(IClaimRepositoryAsync claimRepository,IMapper mapper)
            {
                _claimRepository = claimRepository;
                _mapper = mapper;
            }
            public async Task<Response<IEnumerable<GetAllClaimsViewModel>>> Handle(GetClaimsBySearchQuery query, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetClaimsBySearch(query.searchString);
                var claimViewModel = _mapper.Map<IEnumerable<GetAllClaimsViewModel>>(claim);
             
                if (claim == null) throw new ApiException($"Claim Not Found.");
                return new Response<IEnumerable<GetAllClaimsViewModel>>(claimViewModel);

                //var validFilter = _mapper.Map<GetAllClaimsParameter>(request);
                //var claim = await _claimRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
                //var claimViewModel = _mapper.Map<IEnumerable<GetAllClaimsViewModel>>(claim);
                //return new PagedResponse<IEnumerable<GetAllClaimsViewModel>>(claimViewModel, validFilter.PageNumber, validFilter.PageSize);

            }
        }
    }
}
