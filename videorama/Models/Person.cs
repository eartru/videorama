using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videorama.Models
{
    public class Person
    {
        private int idPerson;
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private Profession profession;

        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Profession Profession { get; set; }
    }
}