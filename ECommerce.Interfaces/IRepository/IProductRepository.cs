using ECommerce.Entity.Product;

namespace ECommerce.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int productId);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int productId);
    }
}