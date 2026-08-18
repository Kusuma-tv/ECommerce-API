using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Wishlist
{
    public class Wishlist
    {
        public int WishlistId { get; set; }

        public int UserId { get; set; }

        public User.User User { get; set; }

        public List<WishlistItem> WishlistItems { get; set; }
    }
}