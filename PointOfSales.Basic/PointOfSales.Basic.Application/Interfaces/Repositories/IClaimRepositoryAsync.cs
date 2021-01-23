using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Interfaces.Repositories
{
    public interface IClaimRepositoryAsync : IGenericRepositoryAsync<Claim>
    {
        Task<IReadOnlyList<Claim>> GetClaimsBySearch(string text);
        Task<Claim> GetClaimById(int id);
    }
}
