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

namespace PointOfSales.Basic.Application.Features.Claims.Queries.GetClaimById
{
    public class GetClaimsBySearchQuery : IRequest<Response<Claim>>
    {
        public int Id { get; set; }
        public class GetClaimsBySearchQueryHandler : IRequestHandler<GetClaimsBySearchQuery, Response<Claim>>
        {
            private readonly IClaimRepositoryAsync _claimRepository;
            public GetClaimsBySearchQueryHandler(IClaimRepositoryAsync claimRepository)
            {
                _claimRepository = claimRepository;
            }
            public async Task<Response<Claim>> Handle(GetClaimsBySearchQuery query, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetByIdAsync(query.Id);
                if (claim == null) throw new ApiException($"Claim Not Found.");
                return new Response<Claim>(claim);
            }
        }
    }
}
