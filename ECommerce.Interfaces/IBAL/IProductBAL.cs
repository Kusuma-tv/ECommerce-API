using ECommerce.Entity.Product;

namespace ECommerce.Interfaces.IBAL
{
    public interface IProductBAL
    {
        Task<ProductResponse> AddAsync(
            ProductRequest request);

        Task<ProductListResponse> GetAllAsync();

        Task<ProductResponse> GetByIdAsync(
            int productId);

        Task<ProductResponse> UpdateAsync(
            int productId,
            ProductRequest request);

        Task<ProductResponse> DeleteAsync(
            int productId);
    }
}