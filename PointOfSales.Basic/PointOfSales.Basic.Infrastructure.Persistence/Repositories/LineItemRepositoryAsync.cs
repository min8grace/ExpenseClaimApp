using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Domain.Entities;
using PointOfSales.Basic.Infrastructure.Persistence.Contexts;
using PointOfSales.Basic.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSales.Basic.Infrastructure.Persistence.Repositories
{
    public class LineItemRepositoryAsync : GenericRepositoryAsync<ClaimLineItem>, ILineItemRepositoryAsync
    {
        //private readonly DbSet<Claim> _claim;

        public LineItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            //_claim = dbContext.Set<Claim>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _products
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
