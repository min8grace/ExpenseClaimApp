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

namespace PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem
{
    public class CreateLineItemCommand : IRequest<Response<int>>
    {
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public Decimal USDAmount { get; set; }

        //public byte[] Receipt { get; set; }//image

        //public virtual Claim Claim { get; set; }
        //public virtual Category Category { get; set; }
        //public virtual Currency Currency { get; set; }
    }
    public class CreateLineItemCommandHandler : IRequestHandler<CreateLineItemCommand, Response<int>>
    {
        private readonly ILineItemRepositoryAsync _lineItemRepository;
        private readonly IMapper _mapper;
        public CreateLineItemCommandHandler(ILineItemRepositoryAsync lineItemRepository, IMapper mapper)
        {
            _lineItemRepository = lineItemRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLineItemCommand request, CancellationToken cancellationToken)
        {
            var lineItem = _mapper.Map<Domain.Entities.LineItem>(request);
            await _lineItemRepository.AddAsync(lineItem);
            return new Response<int>(lineItem.Id);
        }
    }
}
