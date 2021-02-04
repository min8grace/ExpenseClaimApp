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
    public class CurrencyRepositoryAsync : GenericRepositoryAsync<Currency>, ICurrencyRepositoryAsync
    {
        //private readonly DbSet<Currency> _currency;
        private readonly ApplicationDbContext _dbContext;

        public CurrencyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            //_currency = dbContext.Set<Currency>();
        }

        public async Task<Currency> GetCurrencyById(string code)
        {
            return await _dbContext.Currencies
                .FindAsync(code);

        }
    }
}
