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
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        //private readonly DbSet<Category> _category;
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            //_category = dbContext.Set<Category>();
        }
    }
}
