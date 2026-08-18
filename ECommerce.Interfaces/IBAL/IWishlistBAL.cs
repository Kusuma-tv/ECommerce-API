using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Wishlist;

namespace ECommerce.Interfaces.IBAL
{
    public interface IWishlistBAL
    {
        Task<WishlistResponse> AddAsync(
            int userId,
            WishlistRequest request);

        Task<WishlistResponse> GetAsync(
            int userId);

        Task<WishlistResponse> DeleteAsync(
            int userId,
            int wishlistItemId);
    }
}
