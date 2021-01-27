using AutoMapper;
using BlazorApp.Model;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class ClaimEditBase : ComponentBase
    {
        [Inject]
        public IClaimService ClaimService { get; set; }
        private Claim Claim { get; set; } = new Claim();
        public EditClaimModel EditClaimModel { get; set; } = new EditClaimModel();

        [Inject]
        public ICategoryService CategoryService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<GetAllCategoriesViewModel> Categories { get; set; } = new List<GetAllCategoriesViewModel>();
        public string CategoryId { get; set; }

        public string requesterComments { get; set; } = string.Empty;
        public string approverComments { get; set; } = string.Empty;
        public string financeComments { get; set; } = string.Empty;


        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Id = Id ?? "1";
            int.TryParse(Id, out int claimId);
            if (claimId != 0)
            {
                //PageHeader = "Edit Claim";
                Claim = (await ClaimService.GetClaimById(int.Parse(Id)));
                Mapper.Map(Claim, EditClaimModel);

               
                requesterComments = EditClaimModel.RequesterComments;
                approverComments = EditClaimModel.ApproverComments;
                financeComments = EditClaimModel.FinanceComments;
            }
            else
            {
                //PageHeader = "Create Claim";
                Claim = new Claim
                {
                    //LineItems Id = 1,
                    SubmitDate = DateTime.Now,
                    RequesterComments = " ",
                    ApproverComments = " ",
                    FinanceComments = " ",
                    Status = (Status)Enum.Parse(typeof(Status), "Requested")
                };
            }

            Categories = (await CategoryService.GetCategories()).ToList();  
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditClaimModel, Claim);

            Claim result = null;
            if(Claim.Id != 0)
            {
               result = await ClaimService.UpdateClaim(Claim);
            }
            else
            {
                result = await ClaimService.CreateClaim(Claim);
            }          

            if (result != null)
            {
                NavigationManager.NavigateTo("/", true);
            }
        }
    }
}
