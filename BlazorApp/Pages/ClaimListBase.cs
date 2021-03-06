﻿using BlazorApp.Services;
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

        public List<GetAllClaimsViewModel> Claims { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int ClaimId { get; set; }

        protected GlobalUse.Components.ConfirmBase DeleteConfirmation { get; set; }
        //protected void Delete_Click()
        //{
        //    DeleteConfirmation.Show();
        //}
        protected async Task Delete_Click()
        {
            await ClaimService.DeleteClaim(ClaimId);
            NavigationManager.NavigateTo("/", true);
        }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await ClaimService.DeleteClaim(ClaimId);
                NavigationManager.NavigateTo("/", true);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Claims = (await ClaimService.GetClaims()).ToList();
        }
    }
}
