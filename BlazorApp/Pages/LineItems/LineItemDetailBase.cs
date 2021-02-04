using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Pages.LineItems
{
    public class LineItemDetailBase : ComponentBase
    {
        [Inject]
        public ILineItemService LineItemService { get; set; }

        public LineItem LineItem { get; set; }

        public IEnumerable<LineItem> LineItems { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            LineItem = await LineItemService.GetLineItemById(int.Parse(Id));
        }
    }
}
