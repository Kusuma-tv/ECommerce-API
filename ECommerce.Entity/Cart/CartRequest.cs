using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Cart
{
    public class CartRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}