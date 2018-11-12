using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class Rent
    {
        private int idRent;
        private List<Product> products;
        private bool inProgress;
        private Bill bill;

        private int IdRent { get; set; }
        private List<Product> Products { get; set; }
        private bool InProgress { get; set; }
        private Bill Bill { get; set; }
    }
}