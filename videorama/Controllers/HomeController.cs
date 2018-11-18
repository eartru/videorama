using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int nbProducts = 5;
            ProductsDb dbProducts = new ProductsDb();
            int idCustomer = 1;
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            AccueilViewModel vm = new AccueilViewModel
            {
                Product = dbProducts.GetTopNProducts(nbProducts),
                NewProducts = dbProducts.GetNewProducts(),
                Rent = dbRent.GetRentByCustomer(idCustomer),
        };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(AccueilViewModel MV)
        {
            int SelectedValue = MV.SelectedTop;
            return View(MV);
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

        public ActionResult Search(string SearchString)
        {
            string selectType;
            selectType = Request.Form["selectType"];           
            
            return RedirectToAction("ProductsSearchResult", "Products", new { type = selectType, name = SearchString });
        }
    }
}