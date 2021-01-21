using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class ClaimListBase : ComponentBase
    {

        [Inject]
        public IClaimService ClaimService { get; set; }

        public List<GetAllLineItemsViewModel> Claims { get; set; }

        List<Claim> tempList = new List<Claim>();
        Claim temp = new Claim {

            Id = 1,
            Title = "title",
            Requester = 10,
            Approver = 10,
            SubmitDate = new DateTime(1980, 10, 5),
            ApprovalDate = new DateTime(1980, 10, 5),
            ProcessedDate = new DateTime(1980, 10, 5),
            TotalAmount = 20,
            Status = "status",
            RequesterComments = "requesterComments",
            ApproverComments = "approverComments",
            FinanceComments = "financeComments"
        };
        

        protected override async Task OnInitializedAsync()
        {
            

            Claims = (await ClaimService.GetClaims()).ToList();
            //Claims = tempList;
        }
    }
}
