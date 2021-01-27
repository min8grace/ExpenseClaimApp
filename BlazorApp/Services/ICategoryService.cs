using PointOfSales.Basic.Application.Features.Categories.Queries.GetAllCategories;
using PointOfSales.Basic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoriesViewModel>> GetCategories();

        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategory(Category newCategory);

        Task<Category> UpdateCategory(Category updatedCategory);

        Task DeleteCategory(int id);
    }
}
