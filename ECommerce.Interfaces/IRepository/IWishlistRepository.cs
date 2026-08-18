using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Product;
using ECommerce.Entity.Wishlist;

namespace ECommerce.Interfaces.IRepository
{
    public interface IWishlistRepository
    {
        Task<Product?> GetProductByIdAsync(
            int productId);

        Task<Wishlist?> GetByUserIdAsync(
            int userId);

        Task<Wishlist> CreateAsync(
            Wishlist wishlist);

        Task<WishlistItem?> GetItemAsync(
            int wishlistId,
            int productId);

        Task<WishlistItem> CreateItemAsync(
            WishlistItem wishlistItem);

        Task<WishlistItem?> GetItemByIdAsync(
            int wishlistItemId,
            int userId);

        Task DeleteItemAsync(
            WishlistItem wishlistItem);
    }
}
