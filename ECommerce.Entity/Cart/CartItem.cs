using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Cart
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Cart Cart { get; set; }

        public Product.Product Product { get; set; }
    }
}