using Microsoft.AspNetCore.Components;
using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;
        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private const int apiversion = 1;

        public async Task<List<GetAllCategoriesViewModel>> GetCategories()
        {
            return await httpClient.GetJsonAsync<List<GetAllCategoriesViewModel>>($"api/v{apiversion}/Category");
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var x = await httpClient.GetJsonAsync<Category>($"api/v{apiversion}/Category/{id}");
            return x;
        }

        public Task<Category> CreateCategory(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(Category updatedCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
