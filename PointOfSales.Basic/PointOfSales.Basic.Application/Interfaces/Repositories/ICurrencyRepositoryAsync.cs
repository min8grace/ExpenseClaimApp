using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales.Basic.Application.Interfaces.Repositories
{
    public interface ICurrencyRepositoryAsync : IGenericRepositoryAsync<Currency>
    {
        Task<Currency> GetCurrencyById(string code);
    }
}
