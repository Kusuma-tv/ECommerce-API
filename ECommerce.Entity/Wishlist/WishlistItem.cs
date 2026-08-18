using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Wishlist
{
    public class WishlistItem
    {
        public int WishlistItemId { get; set; }

        public int WishlistId { get; set; }

        public int ProductId { get; set; }

        public Wishlist Wishlist { get; set; }

        public Product.Product Product { get; set; }
    }
}
