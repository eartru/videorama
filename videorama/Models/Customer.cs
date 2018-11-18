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
        private List<Bill> bills;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public List<Rent> Rents { get; set; }
        public List<Bill> Bills { get; set; }

    }
}