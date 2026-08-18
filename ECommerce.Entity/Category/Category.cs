using ECommerce.Entity.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Entity.Category
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<ECommerce.Entity.Product.Product> Products { get; set; }
    = new List<ECommerce.Entity.Product.Product>();
    }
}