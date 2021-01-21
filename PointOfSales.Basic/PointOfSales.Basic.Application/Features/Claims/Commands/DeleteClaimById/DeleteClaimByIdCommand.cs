using MediatR;
using PointOfSales.Basic.Application.Exceptions;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Claims.Commands.DeleteClaimById
{
    public class DeleteLineItemByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteClaimByIdCommandHandler : IRequestHandler<DeleteLineItemByIdCommand, Response<int>>
        {
            private readonly IClaimRepositoryAsync _claimRepository;
            public DeleteClaimByIdCommandHandler(IClaimRepositoryAsync claimRepository)
            {
                _claimRepository = claimRepository;
            }
            public async Task<Response<int>> Handle(DeleteLineItemByIdCommand command, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetByIdAsync(command.Id);
                if (claim == null) throw new ApiException($"Claim Not Found.");
                await _claimRepository.DeleteAsync(claim);
                return new Response<int>(claim.Id);
            }
        }
    }
}
