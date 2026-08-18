using ECommerce.Entity.Cart;
using ECommerce.Entity.Order;

namespace ECommerce.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task<Cart?> GetCartAsync(
            int cartId,
            int userId);

        Task<Order> CreateAsync(
            Order order,
            ICollection<CartItem> cartItems);

        Task<Order?> GetByIdAsync(
            int orderId,
            int userId);

        Task<List<Order>> GetAllAsync(
            int userId);
    }
}