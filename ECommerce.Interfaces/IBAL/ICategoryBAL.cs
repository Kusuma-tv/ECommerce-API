using ECommerce.Entity.Category;

namespace ECommerce.Interfaces.IBAL
{
    public interface ICategoryBAL
    {
        Task<CategoryResponse> CreateAsync(CategoryRequest request);

        Task<CategoryListResponse> GetAllAsync();

        Task<CategoryResponse> GetByIdAsync(int categoryId);

        Task<CategoryResponse> UpdateAsync(
            int categoryId,
            CategoryRequest request);

        Task<CategoryResponse> DeleteAsync(int categoryId);
        Task<CategoryWithProductsResponse> GetByIdWithProductsAsync(int categoryId);
        Task<CategoryWithProductsListResponse> GetAllWithProductsAsync();
    }
}