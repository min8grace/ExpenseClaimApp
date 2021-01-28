using AutoMapper;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Features.LineItem.Commands.CreateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Commands.UpdateLineItem;
using PointOfSales.Basic.Application.Features.LineItems.Queries.GetAllLineItems;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class LineItemService : ILineItemService
    {
        private readonly HttpClient httpClient;
        private readonly IMapper _mapper;

        public LineItemService(HttpClient httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            _mapper = mapper;

        }

        private const int apiversion = 1;

        public async Task<List<GetAllLineItemsViewModel>> GetLineItems()
        {
            return await httpClient.GetJsonAsync<List<GetAllLineItemsViewModel>>($"api/v{apiversion}/LineItem");
        }

        public async Task<LineItem> GetLineItemById(int id)
        {
            return await httpClient.GetJsonAsync<LineItem>($"api/v{apiversion}/LineItem/{id}");
        }

        public async Task<LineItem> CreateLineItem(LineItem newLineItem)
        {
            CreateLineItemCommand createLineItemCommand = _mapper.Map<CreateLineItemCommand>(newLineItem);
            return await httpClient.PostJsonAsync<LineItem>($"api/v{apiversion}/LineItem", createLineItemCommand);
        }

        public async Task<LineItem> UpdateLineItem(LineItem updatedLineItem)
        {
            UpdateLineItemCommand updateLineItemCommand = _mapper.Map<UpdateLineItemCommand>(updatedLineItem);
            return await httpClient.PutJsonAsync<LineItem>($"api/v{apiversion}/LineItem", updateLineItemCommand);
        }

        public async Task DeleteLineItem(int id)
        {
            await httpClient.DeleteAsync($"api/v{apiversion}/LineItem/{id}");
        }

        public Task<IReadOnlyList<LineItem>> GetLineItemsBySearch(string text)
        {
            throw new NotImplementedException();
        }
        // return await httpClient.GetJsonAsync<LineItem[]>("api/v1/LineItem");
    }
}
