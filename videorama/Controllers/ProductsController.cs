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
        /// <summary>
        /// Show view with the list of product with a given product type
        /// </summary>
        /// <param name="type"></param>
        /// <returns>View</returns>
        public ActionResult ProductsList(int type)
        {
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();
            List<Product> list = dbProducts.GetProductsByType(type);
            string typeName = list[0].TypeP.TypeName;
            ViewData["type"] = typeName;
            return View(dbProducts.GetProductsByType(type));
        }

        /// <summary>
        /// Show detail of a specific product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public ActionResult Details(int id)
        {
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();

            return View(dbProducts.GetProductsDetail(id));
        }

        /// <summary>
        /// Show a list of product, it's the result of the search bar
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns>View</returns>
        public ActionResult ProductsSearchResult(int type, string name)
        {
            ModelState.Clear();

            ProductsDb dbProducts = new ProductsDb();
            List<Product> listProductFound;
            listProductFound = dbProducts.SearchProductByNameAndType(type, name);

            return View(listProductFound);
        }

        /// <summary>
        /// Add a selected product in the basket
        /// Only the user can do it
        /// </summary>
        /// <param name="idProduct"></param>
        /// <returns>Redirect</returns>
        [Authorize(Roles = "User")]
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

            // If not yet in the basket, add it
            if (!isFound)
            {
                // Add the product id in a new the auth cookie
                // Create a new auth cookie, because can't edit the existing auth cookie
                claimIdentity.AddClaim(new Claim(ClaimTypes.UserData, idProduct));
                authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(
                    new ClaimsPrincipal(claimIdentity),
                    new AuthenticationProperties { IsPersistent = true }
                );
            }
 
            return RedirectToAction("Details", new { id = idProduct });
        }

        /// <summary>
        /// Show the basket
        /// Only the user can do it
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "User")]
        public ActionResult Basket()
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            var idstYet = claimIdentity.FindAll(ClaimTypes.UserData);// List of the products id

            ModelState.Clear();
            
            ProductsDb dbProducts = new ProductsDb();
            List<Product> listProductFound = new List<Product>(); 
            Product productFound;

            // Search all products id in the auth cookie
            foreach(var id in idstYet)
            {
                // Don't take the first because it's ""
                if (id.Value != "")
                {
                    // Find the product in DB
                    productFound = dbProducts.GetProductsDetail(Convert.ToInt32(id.Value)).Item1;
                    if (productFound != null)
                    {
                        listProductFound.Add(productFound);
                    }
                }
                
            }
            
            return View(listProductFound);
        }

        /// <summary>
        /// In DB : Create the Rent with all products in the basket
        /// Only the user can do it
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>Redirect</returns>
        [Authorize(Roles = "User")]
         [HttpPost]
        public ActionResult Basket(FormCollection collection)
        {
            RentDb dbRent = new RentDb();
            ProductsDb dbProduct = new ProductsDb();
            bool rent = false;
            bool isRemove = false;
            bool resultat = false;

            var claimIdentity = User.Identity as ClaimsIdentity;
            int idUser = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            var productList = claimIdentity.FindAll(ClaimTypes.UserData);

            if (collection["getRentDate"] != null)
            {
                foreach (var product in productList)
                {
                    if(product.Value != "")
                    {
                        // Down the product's stock in DB
                        isRemove = dbProduct.RemoveStock(Convert.ToInt32(product.Value));
                        resultat = isRemove;
                        if (isRemove == false)
                        {
                            break;
                        }
                    }
                    
                }
            }

            // Create the rent in DB with the date when the customer will get the products in the shop
            if (resultat)
            {
                rent = dbRent.AddRent(Convert.ToDateTime(collection["getRentDate"]), idUser, productList);
                RemoveAllProductBasket();// Remove all products in basket
                return RedirectToAction("Rents", "Rents", new { id = idUser });
            }                    

            return RedirectToAction("Basket");
        }

        /// <summary>
        /// Remove specific product in basket
        /// Only the user can do it
        /// </summary>
        /// <param name="idProduct"></param>
        /// <returns>Redirect</returns>
        [Authorize(Roles = "User")]
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

        /// <summary>
        /// Call a function to remove all product in basket
        /// Only the user can do it
        /// </summary>
        /// <returns>Redirect</returns>
        [Authorize(Roles = "User")]
        public ActionResult RemoveAllProduct()
        {
            RemoveAllProductBasket();

            return RedirectToAction("Basket");
        }

        /// <summary>
        /// Remove all products in basket
        /// Only the user can do it
        /// </summary>
        /// <returns>Redirect</returns>
        [Authorize(Roles = "User")]
        public bool RemoveAllProductBasket()
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

            return true;
        }
    }
}
