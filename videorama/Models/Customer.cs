using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class Customer : User
    {
        private string firstName;
        private string lastName;
        private string postalCode;
        private string address;
        private string town;
        private string country;
        private List<Rent> rents;

        [Required]
        [Display(Name="Prénom")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Code postal")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Ville")]
        public string Town { get; set; }
        [Required]
        [Display(Name = "Pays")]
        public string Country { get; set; }
        public List<Rent> Rents { get; set; }

    }
}