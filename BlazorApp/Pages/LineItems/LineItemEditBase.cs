using AutoMapper;
using BlazorApp.Model;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCurrencies;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class LineItemEditBase : ComponentBase
    {
        [Inject]
        public ILineItemService LineItemService { get; set; }
        private LineItem LineItem { get; set; } = new LineItem();
        public EditLineItemModel EditLineItemModel { get; set; } = new EditLineItemModel();

        [Inject]
        public ICategoryService CategoryService { get; set; }

        public List<GetAllCategoriesViewModel> Categories { get; set; } = new List<GetAllCategoriesViewModel>();
        public string CategoryId { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        public List<GetAllCurrenciesViewModel> Currencies { get; set; } = new List<GetAllCurrenciesViewModel>();
        public string CurrencyId { get; set; }


        public string Description { get; set; } = string.Empty;

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Id = Id ?? "1";
            //int.TryParse(Id, out int Id);
            if (Id != null) // for Edit
            {                
                LineItem = (await LineItemService.GetLineItemById(int.Parse(Id)));
                Mapper.Map(LineItem, EditLineItemModel);
                Description = EditLineItemModel.Description;
            }
            else // for Create
            {
                //PageHeader = "Create LineItem";
                LineItem = new LineItem
                {
                    //LineItems Id = 1,
                    Date = DateTime.Now,       
                    Description = " ",
                    //Status = (Status)Enum.Parse(typeof(Status), "Requested")
                };
            }

            Categories = (await CategoryService.GetCategories()).ToList();
            CategoryId = LineItem.CategoryId.ToString();
            Currencies = (await CurrencyService.GetCurrencies()).ToList();
            CurrencyId = LineItem.CurrencyCode.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditLineItemModel, LineItem);

            LineItem result = null;
            if (LineItem.Id != 0)
            {
                result = await LineItemService.UpdateLineItem(LineItem);
            }
            else
            {
                result = await LineItemService.CreateLineItem(LineItem);
            }

            if (result != null)
            {
                NavigationManager.NavigateTo($"/detail/{LineItem.ClaimId}", true);
            }
        }
    }
}
