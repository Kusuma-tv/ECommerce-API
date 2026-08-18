using ECommerce.Entity.Cart;
using ECommerce.Entity.Product;

namespace ECommerce.Interfaces.IRepository
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdAsync(int userId);

        Task<Cart> CreateAsync(Cart cart);

        Task<Product?> GetProductByIdAsync(int productId);

        Task<CartItem?> GetCartItemAsync(
            int cartId,
            int productId);

        Task<CartItem?> GetCartItemByIdAsync(
            int cartItemId);

        Task<CartItem> CreateCartItemAsync(
            CartItem cartItem);

        Task<bool> UpdateCartItemAsync(
            CartItem cartItem);

        Task<bool> DeleteCartItemAsync(
            int cartItemId);
    }
}