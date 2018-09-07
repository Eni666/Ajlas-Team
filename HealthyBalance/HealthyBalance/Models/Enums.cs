using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyBalance.Models
{
    public enum Lifestyle
    {
        [Description("Extremt inaktiv")]
        ExtremelyInactive = 1,
        [Description("Stillasittande")]
        Sedentary = 2,
        [Description("Måttligt aktiv")]
        ModeratelyActive = 3,
        [Description("Kraftigt aktiv")]
        VigorouslyActive = 4,
        [Description("Extremt aktiv")]
        ExtremelyActive = 5
    }

    public enum Gender
    {
        [Description("Kvinna")]
        Female,
        [Description("Man")]
        Male
    }

}
