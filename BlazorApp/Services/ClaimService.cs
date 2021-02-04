using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using AutoMapper;
using PointOfSales.Basic.Application.Features.Claims.Commands.UpdateClaim;
using PointOfSales.Basic.Application.Features.Claims.Commands.CreateClaim;

namespace BlazorApp.Services
{
    public class ClaimService : IClaimService
    {
       
        private readonly HttpClient httpClient;
        private readonly IMapper _mapper;
        
        public ClaimService(HttpClient httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            _mapper = mapper;

        }

        private const int apiversion = 1;

        public async  Task<List<GetAllClaimsViewModel>> GetClaims()
        {
            return await httpClient.GetJsonAsync<List<GetAllClaimsViewModel>>($"api/v{apiversion}/Claim");
        }

        public async Task<Claim> GetClaimById(int id)
        {
            return await httpClient.GetJsonAsync<Claim>($"api/v{apiversion}/Claim/{id}");          
        }

        public async Task<Claim> CreateClaim(Claim newClaim)
        {
            CreateClaimCommand createClaimCommand = _mapper.Map<CreateClaimCommand>(newClaim);
            return await httpClient.PostJsonAsync<Claim>($"api/v{apiversion}/Claim", createClaimCommand);
        }

        public async Task<Claim> UpdateClaim(Claim updatedClaim)
        {
            UpdateClaimCommand updateClaimCommand = _mapper.Map<UpdateClaimCommand>(updatedClaim);
            return await httpClient.PutJsonAsync<Claim>($"api/v{apiversion}/Claim", updateClaimCommand);
        }

        public async Task DeleteClaim(int id)
        {
            await httpClient.DeleteAsync($"api/v{apiversion}/Claim/{id}");
        }

        public Task<IReadOnlyList<Claim>> GetClaimsBySearch(string text)
        {
            throw new NotImplementedException();
        }
        // return await httpClient.GetJsonAsync<Claim[]>("api/v1/Claim");


    }
}
