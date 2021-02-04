using PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface ILineItemService
    {
        Task<List<GetAllLineItemsViewModel>> GetLineItems();

        Task<LineItem> GetLineItemById(int id);

        Task<LineItem> CreateLineItem(LineItem newLineItem);

        Task<LineItem> UpdateLineItem(LineItem updatedLineItem);

        Task DeleteLineItem(int id);

        Task<IReadOnlyList<LineItem>> GetLineItemsBySearch(string text);
    }
}
