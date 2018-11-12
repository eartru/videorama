using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videorama.Models;

namespace videorama.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int nbProducts = 5;
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();
            return View(dbProducts.GetTopNProducts(nbProducts));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}