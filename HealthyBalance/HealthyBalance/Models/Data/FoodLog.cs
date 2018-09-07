using System;
using System.Collections.Generic;

namespace HealthyBalance.Models.Data
{
    public partial class FoodLog
    {
        public DateTime Date { get; set; }
        public string MealName { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int Calories { get; set; }
        public int UserId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
