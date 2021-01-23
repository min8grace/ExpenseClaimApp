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

namespace PointOfSales.Basic.Application.Features.LineItems.Queries.GetLineItemById
{
    public class GetLineItemByIdQuery : IRequest<Response<Domain.Entities.LineItem>>
    {
        public int Id { get; set; }
        public class GetLineItemByIdQueryHandler : IRequestHandler<GetLineItemByIdQuery, Response<Domain.Entities.LineItem>>
        {
            private readonly ILineItemRepositoryAsync _lineItemRepository;
            public GetLineItemByIdQueryHandler(ILineItemRepositoryAsync lineItemRepository)
            {
                _lineItemRepository = lineItemRepository;
            }
            public async Task<Response<Domain.Entities.LineItem>> Handle(GetLineItemByIdQuery query, CancellationToken cancellationToken)
            {
                var lineItem = await _lineItemRepository.GetByIdAsync(query.Id);
                if (lineItem == null) throw new ApiException($"LineItem Not Found.");
                return new Response<Domain.Entities.LineItem>(lineItem);
            }
        }
    }
}
