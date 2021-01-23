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
    public class GetClaimByIdQuery : IRequest<Response<Claim>>
    {
        public int Id { get; set; }
        public class GetClaimByIdQueryHandler : IRequestHandler<GetClaimByIdQuery, Response<Claim>>
        {
            private readonly IClaimRepositoryAsync _claimRepository;
            public GetClaimByIdQueryHandler(IClaimRepositoryAsync claimRepository)
            {
                _claimRepository = claimRepository;
                //TEST
            }
            public async Task<Response<Claim>> Handle(GetClaimByIdQuery query, CancellationToken cancellationToken)
            {
                //var claim = await _claimRepository.GetByIdAsync(query.Id);
                var claim = await _claimRepository.GetClaimById(query.Id);

                if (claim == null) throw new ApiException($"Claim Not Found.");
                return new Response<Claim>(claim);
            }
        }
    }
}
