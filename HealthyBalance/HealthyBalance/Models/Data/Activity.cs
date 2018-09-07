using System;
using System.Collections.Generic;

namespace HealthyBalance.Models.Data
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityLog = new HashSet<ActivityLog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? ActivityLevel { get; set; }
        public string Description { get; set; }

        public ICollection<ActivityLog> ActivityLog { get; set; }
    }
}
