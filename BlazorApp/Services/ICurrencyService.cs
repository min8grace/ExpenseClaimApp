using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCurrencies;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface ICurrencyService
    {
        Task<List<GetAllCurrenciesViewModel>> GetCurrencies();

        Task<Currency> GetCurrencyById(int id);

        Task<Currency> CreateCurrency(Currency newCurrency);

        Task<Currency> UpdateCurrency(Currency updatedCurrency);

        Task DeleteCurrency(int id);
    }
}
