using Microsoft.EntityFrameworkCore;
using PointOfSales.Basic.Application.Interfaces.Repositories;
using PointOfSales.Basic.Domain.Entities;
using PointOfSales.Basic.Infrastructure.Persistence.Contexts;
using PointOfSales.Basic.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Infrastructure.Persistence.Repositories
{
    public class ClaimRepositoryAsync : GenericRepositoryAsync<Claim>, IClaimRepositoryAsync
    {
        //private readonly DbSet<Claim> _claim;
        private readonly ApplicationDbContext _dbContext;

        public ClaimRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            //_claim = dbContext.Set<Claim>();
        }

        public async Task<IReadOnlyList<Claim>> GetClaimsBySearch(string searchString)
        {
            IQueryable<Claim> claimsIQ = from x in _dbContext.Claims
                                         select x;
            if(String.IsNullOrEmpty(searchString)){

                claimsIQ = claimsIQ.Where(x => x.Title.Contains(searchString));
            }
            return await claimsIQ.ToListAsync();

        }

        public async Task<Claim> GetClaimById(int id)
        {

            var tclaim = await _dbContext.Claims.FirstOrDefaultAsync(m => m.Id == id); ;

            var temp = await _dbContext.Claims
                .Include(c => c.LineItems)
                .FirstOrDefaultAsync(c => c.Id == id);


            //return await _dbContext.Claims
            //    .Include(c=>c.LineItems)
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(c=>c.Id == id);

            //return await _dbContext.Claims
            //  .FindAsync(id);

            return temp;

        }


        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _products
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
