using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Videorama.Models
{
    public class User
    {
        private int idUser;
        private string username;
        private string email;
        private string password;
        private bool isAdmin;

        public static ClaimsIdentity Identity { get; internal set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        [Remote("IsUserNameExist", "Authentication", ErrorMessage = "Ce nom d\'utilisateur existe déjà")]
        public string Username { get; set; }
        [Required]
        [Remote("IsEmailExist", "Authentication", ErrorMessage = "Cet email existe déjà")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "4 caractères minimum")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}