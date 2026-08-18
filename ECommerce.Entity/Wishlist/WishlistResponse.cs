using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Wishlist
{
    public class WishlistResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public WishlistResult Result { get; set; }
    }

    public class WishlistResult
    {
        public int WishlistId { get; set; }

        public int UserId { get; set; }

        public List<WishlistItemResponse> WishlistItems { get; set; }
    }

    public class WishlistListResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<WishlistResult> Result { get; set; }
    }
}