using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult ProductsList(int type)
        {
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();
            List<Product> list = dbProducts.GetProductsByType(type);
            string typeName = list[0].TypeP.TypeName;
            ViewData["type"] = typeName;
            return View(dbProducts.GetProductsByType(type));
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();

            return View(dbProducts.GetProductsDetail(id));
        }

        // GET: Products search result
        public ActionResult ProductsSearchResult(int type, string name)
        {
            ModelState.Clear();

            ProductsDb dbProducts = new ProductsDb();
            List<Product> listProductFound;
            listProductFound = dbProducts.SearchProductByNameAndType(type, name);

            return View(listProductFound);
        }

        // GET: Add products in basket
        [Authorize]
        public ActionResult AddProductBasket(string idProduct)
        {
            bool isFound = false;
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var claimIdentity = new ClaimsIdentity(User.Identity);

            var idstYet = claimIdentity.FindAll(ClaimTypes.UserData);

            // Check if the product is yet in the basket
            foreach (var id in idstYet)
            {
                if(id.Value == idProduct)
                {
                    isFound = true;
                }
            }

            if (!isFound)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.UserData, idProduct));
                authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(
                    new ClaimsPrincipal(claimIdentity),
                    new AuthenticationProperties { IsPersistent = true }
                );
            }
 
            return RedirectToAction("Details", new { id = idProduct });
        }

        // GET: Show products in basket
        public ActionResult Basket()
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            var idstYet = claimIdentity.FindAll(ClaimTypes.UserData);

            ModelState.Clear();
            
            ProductsDb dbProducts = new ProductsDb();
            List<Product> listProductFound = new List<Product>(); 
            Product productFound;

            foreach(var id in idstYet)
            {
                if (id.Value != "")
                {
                    productFound = dbProducts.GetProductsDetail(Convert.ToInt32(id.Value)).Item1;
                    if (productFound != null)
                    {
                        listProductFound.Add(productFound);
                    }
                }
                
            }
            
            return View(listProductFound);
        }

        // GET: Remove specific product in basket
        [Authorize]
        public ActionResult RremoveProductBasket(string idProduct)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var user = User as ClaimsPrincipal;
            var claimIdentity = User.Identity as ClaimsIdentity;

            var idstYet = claimIdentity.FindAll(ClaimTypes.UserData);

            // Check if the product is yet in the basket
            foreach (var id in idstYet)
            {
                if (id.Value == idProduct)
                {                  
                    var claim = (from c in user.Claims
                                 where c.Value == idProduct
                                 select c).Single();
                    claimIdentity.RemoveClaim(claim);
                    authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(
                        new ClaimsPrincipal(claimIdentity),
                        new AuthenticationProperties { IsPersistent = true }
                    );
                    break;
                }
            }

            return RedirectToAction("Basket");
        }
        
        // GET: Remove all products in basket
        [Authorize]
        public ActionResult RemoveAllProductBasket()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var user = User as ClaimsPrincipal;
            var claimIdentity = User.Identity as ClaimsIdentity;

            var idstYet = claimIdentity.FindAll(ClaimTypes.UserData);

            // Check if the product is yet in the basket
            foreach (var id in idstYet)
            {
                if (id.Value != "")
                {                  
                    claimIdentity.RemoveClaim(id);
                    
                }
            }
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(
                new ClaimsPrincipal(claimIdentity),
                new AuthenticationProperties { IsPersistent = true }
            );

            return RedirectToAction("Basket");
        }
    }
}
