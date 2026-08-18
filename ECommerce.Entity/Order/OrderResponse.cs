using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Order
{
    public class OrderResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public OrderResult Result { get; set; }
    }

    public class OrderResult
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public List<OrderItemResponse> OrderItems { get; set; }
    }

    public class OrderListResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<OrderResult> Result { get; set; }
    }
}