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
    public class LineItemRepositoryAsync : GenericRepositoryAsync<LineItem>, ILineItemRepositoryAsync
    {
         private readonly ApplicationDbContext _dbContext;
        //private readonly DbSet<Claim> _claim;

        public LineItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            //_claim = dbContext.Set<Claim>();

        }



        public async Task<LineItem> GetLineItemById(int id)
        {
            return await _dbContext.LineItems.FindAsync(id);
                //.Include(c => c.)
                //.FirstOrDefaultAsync(c => c.Id == id);

        }


        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _products
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
