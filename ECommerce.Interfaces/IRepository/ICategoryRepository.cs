using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Entity.Category;

namespace ECommerce.Interfaces.IRepository
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int categoryId);

        Task<bool> UpdateAsync(Category category);

        Task<bool> DeleteAsync(int categoryId);
        Task<Category?> GetByIdWithProductsAsync(int categoryId);
        Task<List<Category>> GetAllWithProductsAsync();
    }
}