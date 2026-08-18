using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.DataAccess;
using ECommerce.Entity.Product;
using ECommerce.Entity.Wishlist;
using ECommerce.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly AppDbContext _context;

        public WishlistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(
            int productId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(
                    p => p.ProductId == productId);
        }

        public async Task<Wishlist?> GetByUserIdAsync(
            int userId)
        {
            return await _context.Wishlists
                .Include(w => w.WishlistItems)
                .ThenInclude(wi => wi.Product)
                .FirstOrDefaultAsync(
                    w => w.UserId == userId);
        }

        public async Task<Wishlist> CreateAsync(
            Wishlist wishlist)
        {
            await _context.Wishlists.AddAsync(wishlist);

            await _context.SaveChangesAsync();

            return wishlist;
        }

        public async Task<WishlistItem?> GetItemAsync(
            int wishlistId,
            int productId)
        {
            return await _context.WishlistItems
                .FirstOrDefaultAsync(
                    wi => wi.WishlistId == wishlistId &&
                          wi.ProductId == productId);
        }

        public async Task<WishlistItem> CreateItemAsync(
            WishlistItem wishlistItem)
        {
            await _context.WishlistItems.AddAsync(wishlistItem);

            await _context.SaveChangesAsync();

            return wishlistItem;
        }

        public async Task<WishlistItem?> GetItemByIdAsync(
            int wishlistItemId,
            int userId)
        {
            return await _context.WishlistItems
                .Include(wi => wi.Wishlist)
                .FirstOrDefaultAsync(
                    wi => wi.WishlistItemId == wishlistItemId &&
                          wi.Wishlist.UserId == userId);
        }

        public async Task DeleteItemAsync(
            WishlistItem wishlistItem)
        {
            _context.WishlistItems.Remove(wishlistItem);

            await _context.SaveChangesAsync();
        }
    }
}