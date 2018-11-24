using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videorama.Models;

namespace videorama.ViewModels
{
    public class BillViewModel
    {
        internal RentDb dbrent;

        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public Rent Rent { get; set; }
        public decimal Total { get; set; }
    }
}