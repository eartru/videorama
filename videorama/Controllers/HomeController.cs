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
        /// <summary>
        /// Show the index page.
        /// The content depends on whether the user is connected or not
        /// The page contains the new products and the top n of rented products for anyone
        /// It shows the products currently rented by someone if he's connected
        /// </summary>
        /// <returns>View</returns>
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

        /// <summary>
        /// Show in a partial view the result of top n rented products
        /// In the index page, the user choose top 5, 10, 25 etc 
        /// and then the partial view ask the the ressult to the database 
        /// depending on the user demand
        /// </summary>
        /// <param name="topValue"></param>
        /// <returns>PartialView</returns>
        public ActionResult IndexTop(int topValue)
        {
            ProductsDb dbProducts = new ProductsDb();
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            AccueilViewModel vm = new AccueilViewModel
            {
                Product = dbProducts.GetTopNProducts(topValue)
            };
            return PartialView(vm);
        }

        /// <summary>
        /// Redirect to the controller products, action ProductsSearchResult,
        /// which display the result of the search depending on type and SearchString
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns>RedirectToAction</returns>
        public ActionResult Search(string SearchString)
        {
            string selectType;
            selectType = Request.Form["selectType"];           
            
            return RedirectToAction("ProductsSearchResult", "Products", new { type = selectType, name = SearchString });
        }
    }
}