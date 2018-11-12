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

        public int IdRent { get; set; }
        public List<Product> Products { get; set; }
        public bool InProgress { get; set; }
        public Bill Bill { get; set; }
    }
}