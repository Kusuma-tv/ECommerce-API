using System;
using System.Collections.Generic;

namespace ECommerce.Entity.Product
{
    public class ProductResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public ProductResult? Result { get; set; }
    }

    public class ProductListResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public List<ProductResult> Result { get; set; }
            = new List<ProductResult>();
    }

    public class ProductResult
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}