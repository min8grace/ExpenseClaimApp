using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;

namespace BlazorApp.Services
{
    public class ClaimService : IClaimService
    {

       
        private readonly HttpClient httpClient;

        public ClaimService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private const int apiversion = 1;



        public async  Task<List<GetAllLineItemsViewModel>> GetClaims()
        {

            return await httpClient.GetJsonAsync<List<GetAllLineItemsViewModel>>($"api/v{apiversion}/Claim");
        }
        // return await httpClient.GetJsonAsync<Claim[]>("api/v1/Claim");


    }
}
