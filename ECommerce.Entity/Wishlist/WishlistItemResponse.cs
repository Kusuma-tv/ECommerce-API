using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Wishlist
{
    public class WishlistItemResponse
    {
        public int WishlistItemId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
