using MediatR;
using PointOfSales.Basic.Application.Exceptions;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Features.LineItems.Commands.DeleteLineItemyId
{
    public class DeleteLineItemByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteLineItemByIdCommandHandler : IRequestHandler<DeleteLineItemByIdCommand, Response<int>>
        {
            private readonly ILineItemRepositoryAsync _lineItemRepository;
            public DeleteLineItemByIdCommandHandler(ILineItemRepositoryAsync lineItemRepository)
            {
                _lineItemRepository = lineItemRepository;
            }
            public async Task<Response<int>> Handle(DeleteLineItemByIdCommand command, CancellationToken cancellationToken)
            {
                var lineItem = await _lineItemRepository.GetByIdAsync(command.Id);
                if (lineItem == null) throw new ApiException($"Claim Not Found.");
                await _lineItemRepository.DeleteAsync(lineItem);
                return new Response<int>(lineItem.Id);
            }
        }
    }
}
