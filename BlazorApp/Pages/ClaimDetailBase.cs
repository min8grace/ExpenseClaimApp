using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class ClaimDetailBase : ComponentBase
    {
        [Inject]
        public IClaimService ClaimService { get; set; }

        public Claim Claim { get; set; }
        
        public IEnumerable<Claim> Claims { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Claim = await ClaimService.GetClaimById(int.Parse(Id));
        }
    }
}
