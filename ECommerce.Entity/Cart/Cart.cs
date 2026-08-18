using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Cart
{
    public class Cart
    {
        public int CartId { get; set; }

        public int UserId { get; set; }

        public User.User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
