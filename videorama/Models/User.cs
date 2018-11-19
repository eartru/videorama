using System;
using System.Collections.Generic;
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

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}