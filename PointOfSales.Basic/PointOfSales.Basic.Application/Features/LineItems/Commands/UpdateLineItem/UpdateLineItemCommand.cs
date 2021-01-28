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

namespace PointOfSales.Basic.Application.Features.LineItems.Commands.UpdateLineItem
{
    
    public class UpdateLineItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
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


        public class UpdateLineItemCommandHandler : IRequestHandler<UpdateLineItemCommand, Response<int>>
        {
            private readonly ILineItemRepositoryAsync _lineItemRepository;
            public UpdateLineItemCommandHandler(ILineItemRepositoryAsync lineItemRepository)
            {
                _lineItemRepository = lineItemRepository;
            }
            public async Task<Response<int>> Handle(UpdateLineItemCommand command, CancellationToken cancellationToken)
            {
                var lineItem = await _lineItemRepository.GetByIdAsync(command.Id);

                if (lineItem == null)
                {
                    throw new ApiException($"Claim Not Found.");
                }
                else
                {                   
                    lineItem.ClaimId = command.ClaimId;
                    lineItem.CategoryId = command.CategoryId;
                    lineItem.Payee = command.Payee;
                    lineItem.Date = command.Date;
                    lineItem.Description = command.Description;
                    lineItem.Amount = command.Amount;
                    lineItem.CurrencyCode = command.CurrencyCode;
                    lineItem.USDAmount = command.USDAmount;

                    await _lineItemRepository.UpdateAsync(lineItem);
                    return new Response<int>(lineItem.Id);
                }
            }
        }
    }

}
