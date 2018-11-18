using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videorama.Models;

namespace videorama.ViewModels
{
    public class RentsViewModel
    {
        public IEnumerable<Tuple<Rent,Product>> Products { get; set; }
        public IEnumerable<int> IdRent { get; set; }
    }
}