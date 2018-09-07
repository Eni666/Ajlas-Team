using HealthyBalance.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyBalance.Models.View
{ 

    public class ActivityLogViewModel
    {
        public DateTime Date { get; set; }
        public int ActivityId { get; set; }
        public TimeSpan Duration { get; set; }
        public int Consumption { get; set; }
        public int UserId { get; set; }

        public Data.Activity Activity { get; set; }
        public User User { get; set; }

        public SelectList ActivityList { get; set; }
    }
}
