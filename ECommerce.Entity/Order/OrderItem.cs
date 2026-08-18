using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Order
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public Order Order { get; set; }

        public Product.Product Product { get; set; }
    }
}
