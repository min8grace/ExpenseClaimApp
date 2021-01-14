using Microsoft.EntityFrameworkCore;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Domain.Entities;
using PointOfSales.Basic.Infrastructure.Persistence.Contexts;
using PointOfSales.Basic.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Infrastructure.Persistence.Repositories
{
    class ClaimRepositoryAsync : GenericRepositoryAsync<Claim>, IClaimRepositoryAsync
    {
        private readonly DbSet<Claim> _products;

        public ClaimRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Claim>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _products
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
