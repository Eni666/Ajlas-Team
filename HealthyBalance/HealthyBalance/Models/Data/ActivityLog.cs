using System;
using System.Collections.Generic;

namespace HealthyBalance.Models.Data
{
    public partial class ActivityLog
    {

        public DateTime Date { get; set; }
        public int ActivityId { get; set; }
        public TimeSpan Duration { get; set; }
        public int Consumption { get; set; }
        public int UserId { get; set; }

        public Activity Activity { get; set; }
        public User User { get; set; }
    }
}
