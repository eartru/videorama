using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace videorama.ViewModels
{
    public class PasswordViewModel
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "4 caractères minimum")]
        public string Password { get; set; }
    }
}