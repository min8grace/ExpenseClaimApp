using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Features.Currencies.Queries.GetAllCurrencies;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient httpClient;
        public CurrencyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private const int apiversion = 1;

        public async Task<List<GetAllCurrenciesViewModel>> GetCurrencies()
        {
            var y = await httpClient.GetJsonAsync<List<GetAllCurrenciesViewModel>>($"api/v{apiversion}/Currency");
            return y;
        }

        public async Task<Currency> GetCurrencyById(int id)
        {
            var x = await httpClient.GetJsonAsync<Currency>($"api/v{apiversion}/Currency/{id}");
            return x;
        }

        public Task<Currency> CreateCurrency(Currency newCurrency)
        {
            throw new NotImplementedException();
        }

        public Task<Currency> UpdateCurrency(Currency updatedCurrency)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCurrency(int id)
        {
            throw new NotImplementedException();
        }
    }
}
