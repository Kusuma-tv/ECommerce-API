using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Entity.Category;


namespace ECommerce.Entity.Product
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public ECommerce.Entity.Category.Category Category { get; set; } = null!;

    }
}
