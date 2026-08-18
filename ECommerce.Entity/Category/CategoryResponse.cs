using ECommerce.Entity.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Entity.Category
{
    public class CategoryResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public CategoryResult? Result { get; set; }
    }
    

    public class CategoryListResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public List<CategoryResult> Result { get; set; }
            = new List<CategoryResult>();
    }

    public class CategoryResult
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
    public class CategoryWithProductsResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public CategoryWithProductsResult? Result { get; set; }
    }
    public class CategoryWithProductsResult
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<ProductResult> Products { get; set; }
            = new List<ProductResult>();

    }
    public class CategoryWithProductsListResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public List<CategoryWithProductsResult> Result { get; set; }
            = new List<CategoryWithProductsResult>();
    }
}