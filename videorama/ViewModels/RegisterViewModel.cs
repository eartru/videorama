using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videorama.Models;
using Videorama.Models;

namespace videorama.ViewModels
{
    public class RegisterViewModel
    {
        internal CustomerDb dbProducts;

        public Customer Customer { get; set; }
    }
}