using System;
using System.Collections.Generic;
using System.Text;

using ECommerce.Entity.Wishlist;
using ECommerce.Interfaces.IBAL;
using ECommerce.Interfaces.IRepository;

namespace ECommerce.BAL
{
    public class WishlistBAL : IWishlistBAL
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistBAL(
            IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<WishlistResponse> AddAsync(
            int userId,
            WishlistRequest request)
        {
            if (request.ProductId <= 0)
            {
                return new WishlistResponse
                {
                    StatusCode = 400,
                    Message = "Invalid product",
                    Result = null
                };
            }

            var product = await _wishlistRepository
                .GetProductByIdAsync(request.ProductId);

            if (product == null)
            {
                return new WishlistResponse
                {
                    StatusCode = 404,
                    Message = "Product not found",
                    Result = null
                };
            }

            var wishlist = await _wishlistRepository
                .GetByUserIdAsync(userId);

            if (wishlist == null)
            {
                wishlist = new Wishlist
                {
                    UserId = userId,
                    WishlistItems = new List<WishlistItem>()
                };

                wishlist = await _wishlistRepository
                    .CreateAsync(wishlist);
            }

            var existingItem = await _wishlistRepository
                .GetItemAsync(
                    wishlist.WishlistId,
                    request.ProductId);

            if (existingItem != null)
            {
                return new WishlistResponse
                {
                    StatusCode = 400,
                    Message = "Product already exists in wishlist",
                    Result = null
                };
            }

            var wishlistItem = new WishlistItem
            {
                WishlistId = wishlist.WishlistId,
                ProductId = request.ProductId
            };

            await _wishlistRepository
                .CreateItemAsync(wishlistItem);

            return await GetAsync(userId);
        }

        public async Task<WishlistResponse> GetAsync(
            int userId)
        {
            var wishlist = await _wishlistRepository
                .GetByUserIdAsync(userId);

            if (wishlist == null)
            {
                return new WishlistResponse
                {
                    StatusCode = 404,
                    Message = "Wishlist not found",
                    Result = null
                };
            }

            return new WishlistResponse
            {
                StatusCode = 200,
                Message = "Wishlist retrieved successfully",
                Result = MapToResult(wishlist)
            };
        }

        public async Task<WishlistResponse> DeleteAsync(
            int userId,
            int wishlistItemId)
        {
            if (wishlistItemId <= 0)
            {
                return new WishlistResponse
                {
                    StatusCode = 400,
                    Message = "Invalid wishlist item",
                    Result = null
                };
            }

            var wishlistItem = await _wishlistRepository
                .GetItemByIdAsync(
                    wishlistItemId,
                    userId);

            if (wishlistItem == null)
            {
                return new WishlistResponse
                {
                    StatusCode = 404,
                    Message = "Wishlist item not found",
                    Result = null
                };
            }

            await _wishlistRepository
                .DeleteItemAsync(wishlistItem);

            return await GetAsync(userId);
        }

        private WishlistResult MapToResult(
            Wishlist wishlist)
        {
            return new WishlistResult
            {
                WishlistId = wishlist.WishlistId,
                UserId = wishlist.UserId,
                WishlistItems = wishlist.WishlistItems
                    .Select(item => new WishlistItemResponse
                    {
                        WishlistItemId =
                            item.WishlistItemId,

                        ProductId =
                            item.ProductId,

                        ProductName =
                            item.Product.Name,

                        Price =
                            item.Product.Price
                    })
                    .ToList()
            };
        }
    }
}