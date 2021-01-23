using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class ClaimCreateBase : ComponentBase
    {
        [Inject]
        public IClaimService ClaimService { get; set; }

        //public List<GetAllLineItemsViewModel> Claims { get; set; }

        protected override async Task OnInitializedAsync()
        {


            //Claims = (await ClaimService.  ()).ToList();
        
        }
    }
}
