using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyBalance.Models.Data
{
    public partial class User
    {
        public User()
        {
            ActivityLog = new HashSet<ActivityLog>();
            FoodLog = new HashSet<FoodLog>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett förnamn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett efternamn")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Du måste fylla i en e-postadress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ditt lösenord måste innehålla minst sex tecken")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ditt kön")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ditt födelsedatum")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Du måste fylla i din vikt")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Du måste fylla i din längd")]
        public int Length { get; set; }
        public bool Athletic { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ditt livsstil")]
        public int Lifestyle { get; set; }

        public ICollection<ActivityLog> ActivityLog { get; set; }
        public ICollection<FoodLog> FoodLog { get; set; }
    }
}
