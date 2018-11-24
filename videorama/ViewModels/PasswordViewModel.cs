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
        //[MinLength(5, ErrorMessage = "Le mot de passe doit faire 5 caractères minimum")]
        public string Password { get; set; }
    }
}