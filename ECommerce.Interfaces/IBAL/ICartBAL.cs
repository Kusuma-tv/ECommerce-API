using ECommerce.Entity.Cart;

namespace ECommerce.Interfaces.IBAL
{
    public interface ICartBAL
    {
        Task<CartResponse> AddAsync(
            int userId,
            CartRequest request);

        Task<CartResponse> GetAsync(
            int userId);

        Task<CartResponse> UpdateAsync(
            int userId,
            int cartItemId,
            CartRequest request);

        Task<CartResponse> DeleteAsync(
            int userId,
            int cartItemId);
    }
}