using System;
using System.Collections.Generic;

namespace HealthyBalance.Models.Data
{
    public partial class Product
    {
        public Product()
        {
            FoodLog = new HashSet<FoodLog>();
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Calorie { get; set; }

        public ICollection<FoodLog> FoodLog { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
