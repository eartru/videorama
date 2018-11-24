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

            if (Request.IsAuthenticated)
            {
                var claimIdentity = User.Identity as ClaimsIdentity;

                if (claimIdentity != null)
                {
                    role = claimIdentity.FindFirst(ClaimTypes.Role).Value;
                    id = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    idUser = Convert.ToInt32(id);
                }
            }

            ProductsDb dbProducts = new ProductsDb();
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            AccueilViewModel vm = new AccueilViewModel
            {
                NewProducts = dbProducts.GetNewProducts()
            };
            if (Request.IsAuthenticated)
            {
                if(role == "User")
                {
                    vm.Rent = dbRent.GetRentByCustomer(idUser);
                }
            }
            return View(vm);
        }

        // Non utilisé pour le moment, devrait servir pour le dropdown top n des DVD loués
        public ActionResult IndexTop(int topValue)
        {
            ProductsDb dbProducts = new ProductsDb();
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            AccueilViewModel vm = new AccueilViewModel
            {
                Product = dbProducts.GetTopNProducts(topValue)
            };
            // int SelectedValue = MV.SelectedTop;
            return PartialView(vm);
        }

        public ActionResult Search(string SearchString)
        {
            string selectType;
            selectType = Request.Form["selectType"];           
            
            return RedirectToAction("ProductsSearchResult", "Products", new { type = selectType, name = SearchString });
        }
    }
}