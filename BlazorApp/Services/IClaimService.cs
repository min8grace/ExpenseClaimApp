using PointOfSales.Basic.Application.Features.Claims.Queries.GetAllClaims;
using PointOfSales.Basic.Application.Wrappers;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IClaimService
    {
        Task<List<GetAllClaimsViewModel>> GetClaims();

        Task<Claim> GetClaimById(int id);

        Task<Claim> CreateClaim(Claim newClaim);

        Task<Claim> UpdateClaim(Claim updatedClaim);

        Task DeleteClaim(int id);

        Task<IReadOnlyList<Claim>> GetClaimsBySearch(string text);

        //Task<List<Claim>> GetPagedReponseAsync(int pageNumber, int pageSize);
    }
}
