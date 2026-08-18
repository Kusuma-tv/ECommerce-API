using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.DataAccess;
using ECommerce.Entity.Cart;
using ECommerce.Entity.Order;
using ECommerce.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartAsync(
            int cartId,
            int userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(
                    c => c.CartId == cartId &&
                         c.UserId == userId);
        }

        public async Task<Order> CreateAsync(
            Order order,
            ICollection<CartItem> cartItems)
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();

                _context.CartItems.RemoveRange(cartItems);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return order;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Order?> GetByIdAsync(
            int orderId,
            int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(
                    o => o.OrderId == orderId &&
                         o.UserId == userId);
        }

        public async Task<List<Order>> GetAllAsync(
            int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}