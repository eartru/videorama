using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videorama.Models;
using Videorama.Models;

namespace videorama.ViewModels
{
    public class AuthenticationViewModel
    {
        public Customer Customer { get; set; }
        public User User { get; set; }
        public bool Authentifie { get; set; }
    }
}