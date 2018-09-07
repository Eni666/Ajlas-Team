using System;
using System.Collections.Generic;

namespace HealthyBalance.Models.Data
{
    public partial class Category
    {
        public Category()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
