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

namespace PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public int Requester { get; set; }
        public int Approver { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; } = 300.5m;
        public Status Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }
    }
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, Response<int>>
    {
        private readonly IClaimRepositoryAsync _claimRepository;
        private readonly IMapper _mapper;
        public CreateClaimCommandHandler(IClaimRepositoryAsync claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var claim = _mapper.Map<Claim>(request);
            await _claimRepository.AddAsync(claim);
            return new Response<int>(claim.Id);
        }
    }
}
