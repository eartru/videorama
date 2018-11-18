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

        public User() { }

        public User(string email, string password, bool isAdmin = false)
        {
            this.email = email;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}