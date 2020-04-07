﻿using System.ComponentModel.DataAnnotations;

namespace BuildingCondition.Mvc.Models.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        
        [Compare("Password")]
        public string RepeatePassword { get; set; }
        public string UserName { get; set; }
    }
}
