using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entity.Category
{
    public class CategoryRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}