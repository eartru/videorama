using System;
using System.Collections.Generic;
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

        public Customer(string firstName, string name, string email, string password, string address, string postalCode, string town, string country) : base(email, password)
        {
            this.firstName = firstName;
            this.lastName = name;
            this.address = address;
            this.postalCode = postalCode;
            this.town = town;
            this.country = country;

        }

        /*public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public List<Rent> Rents { get; set; }
        public List<Bill> Bills { get; set; }*/

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }




    }
}