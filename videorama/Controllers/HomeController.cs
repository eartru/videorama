using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            string role = "";
            string id = "";
            int idUser = 0;
            bool roleAdmin = false;

            if (Request.IsAuthenticated)
            {
                var claimIdentity = User.Identity as ClaimsIdentity;

                if (claimIdentity != null)
                {
                    role = claimIdentity.FindFirst(ClaimTypes.Role).Value;
                    id = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    idUser = Convert.ToInt32(id);
                    roleAdmin = Convert.ToBoolean(role);
                }
            }

            int nbProducts = 5;
            ProductsDb dbProducts = new ProductsDb();
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            AccueilViewModel vm = new AccueilViewModel
            {
                Product = dbProducts.GetTopNProducts(nbProducts),
                NewProducts = dbProducts.GetNewProducts()
            };
            if (Request.IsAuthenticated)
            {
                if(!roleAdmin)
                {
                    vm.Rent = dbRent.GetRentByCustomer(idUser);
                }
            }
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