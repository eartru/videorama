using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videorama.Models;

namespace videorama.ViewModels
{
    public class AccueilViewModel
    {
        internal ProductsDb dbProducts;

        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Product> NewProducts { get; set; }
        public IEnumerable<Tuple<Rent,Product>> Rent { get; set; }
        public int SelectedTop { get; set; }
        List<SelectListItem> items = new List<SelectListItem>();

    }
}