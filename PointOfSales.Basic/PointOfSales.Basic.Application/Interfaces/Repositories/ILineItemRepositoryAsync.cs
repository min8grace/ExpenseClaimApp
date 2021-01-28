using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Interfaces.Repositories
{
    public interface ILineItemRepositoryAsync : IGenericRepositoryAsync<LineItem>
    {
       // Task<IReadOnlyList<Claim>> GetClaimsBySearch(string text);
        Task<LineItem> GetLineItemById(int id);
    }
}
