using MediatR;
using PointOfSales.Basic.Application.Exceptions;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.Claims.Commands.UpdateClaim
{
    public class UpdateClaimCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Requester { get; set; }
        public int Approver { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }
        public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, Response<int>>
        {
            private readonly IClaimRepositoryAsync _claimRepository;
            public UpdateClaimCommandHandler(IClaimRepositoryAsync claimRepository)
            {
                _claimRepository = claimRepository;
            }
            public async Task<Response<int>> Handle(UpdateClaimCommand command, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetByIdAsync(command.Id);

                if (claim == null)
                {
                    throw new ApiException($"Claim Not Found.");
                }
                else
                {
                    claim.Title = command.Title;
                    claim.Requester = command.Requester;
                    claim.Approver = command.Approver;
                    await _claimRepository.UpdateAsync(claim);
                    return new Response<int>(claim.Id);
                }
            }
        }
    }
}
