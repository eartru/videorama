using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace videorama.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Code postal")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Ville")]
        public string Town { get; set; }
        [Required]
        [Display(Name = "Pays")]
        public string Country { get; set; }
    }
}