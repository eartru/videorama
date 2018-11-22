using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class Rent
    {
        private int idRent;
        private List<Product> products;
        private DateTime rentDate;
        private DateTime returnBackDate;
        private bool inProgress;

        public int IdRent { get; set; }
        public List<Product> Products { get; set; }
        public DateTime RentDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnBackDate { get; set; }
        public bool InProgress { get; set; }
    }
}