using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class Bill
    {
        private int idBill;
        private Rent rent;

        public int IdBill { get; set; }
        public Rent Rent { get; set; }
    }
}