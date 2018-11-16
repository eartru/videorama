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
            var exemploList = new SelectList(new[] { "Exemplo1:", "Exemplo2", "Exemplo3" });
            ViewBag.ExemploList = exemploList;

            System.Diagnostics.Debug.WriteLine("indexxxxxxxxxxxx");
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
            System.Diagnostics.Debug.WriteLine("iciiiiiiii !");
            System.Diagnostics.Debug.WriteLine(SearchString);
            string selectType;
            selectType = Request.Form["selectType"];

            ProductsDb dbProducts = new ProductsDb();
            
           
            List<Product> listProduct;
            listProduct = dbProducts.SearchProductByNameAndType(int.Parse(Request.Form["selectType"]), SearchString);
            
            return RedirectToAction("ProductsSearchresult", "Products", new { listProduct = listProduct });

            //return View();
        }
    }
}