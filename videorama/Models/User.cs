using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class User
    {
        private int idUser;
        private string username;
        private string email;
        private string password;
        private bool isAdmin;

        [Required]
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}