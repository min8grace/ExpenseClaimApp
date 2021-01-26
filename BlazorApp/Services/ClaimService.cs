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


        public async  Task<List<GetAllClaimsViewModel>> GetClaims()
        {
            return await httpClient.GetJsonAsync<List<GetAllClaimsViewModel>>($"api/v{apiversion}/Claim");
        }

        public async Task<Claim> GetClaimById(int id)
        {
            var x = await httpClient.GetJsonAsync<Claim>($"api/v{apiversion}/Claim/{id}"); 
            return x;
        }

        public Task<Claim> CreateClaim(Claim newClaim)
        {
            throw new NotImplementedException();
        }

        public Task<Claim> UpdateClaim(Claim updatedClaim)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClaim(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Claim>> GetClaimsBySearch(string text)
        {
            throw new NotImplementedException();
        }
        // return await httpClient.GetJsonAsync<Claim[]>("api/v1/Claim");


    }
}
