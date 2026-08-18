using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Order
{
    public class OrderItemResponse
    {
        public int OrderItemId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }
    }
}