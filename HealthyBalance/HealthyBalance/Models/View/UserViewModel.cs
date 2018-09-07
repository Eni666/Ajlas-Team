using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyBalance.Models.View
{
    public class UserViewModel
    {
        
        public int ID { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public SelectList GenderList { get; set; }
        public float Weight { get; set; }
        public int Length { get; set; }
        public bool Athletic { get; set; }
        public Lifestyle Lifestyle { get; set; }
        public SelectList Lifestyles { get; set; }


    }
}
