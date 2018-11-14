﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Videorama.Models
{
    public class Product
    {
        private int idProduct;
        private string title;
        private string synopsis;
        private string picture;
        private List<Category> categories;
        private List<Person> casting;
        private DateTime releaseDate;
        private int stock;
        private double price;
        private Type type;

        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Picture { get; set; }
        public List<Category> Categories { get; set; }
        public List<Person> Casting { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public Type Type { get; set; }

    }
}