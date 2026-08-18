using ECommerce.Entity.Cart;
using ECommerce.Entity.Product;
using ECommerce.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<CartItem?> GetCartItemAsync(
            int cartId,
            int productId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(
                    ci => ci.CartId == cartId &&
                          ci.ProductId == productId);
        }

        public async Task<CartItem?> GetCartItemByIdAsync(
            int cartItemId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(
                    ci => ci.CartItemId == cartItemId);
        }

        public async Task<CartItem> CreateCartItemAsync(
            CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            return cartItem;
        }

        public async Task<bool> UpdateCartItemAsync(
            CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCartItemAsync(
            int cartItemId)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(
                    ci => ci.CartItemId == cartItemId);

            if (cartItem == null)
            {
                return false;
            }

            _context.CartItems.Remove(cartItem);

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Product?> GetProductByIdAsync(
    int productId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(
                    p => p.ProductId == productId);
        }
    }
}