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

        [Display(Name = "N° de location")]
        public int IdRent { get; set; }
        [Display(Name = "Liste des produits")]
        public List<Product> Products { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date de location")]
        public DateTime RentDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date de retour")]
        public DateTime ReturnBackDate { get; set; }
        [Display(Name = "En cours")]
        public bool InProgress { get; set; }
    }
}