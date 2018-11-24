using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        // GET: Products search result
        public ActionResult ProductsSearchResult(int type, string name)
        {
            ModelState.Clear();

            ProductsDb dbProducts = new ProductsDb();
            List<Product> listProductFound;
            listProductFound = dbProducts.SearchProductByNameAndType(type, name);

            return View(listProductFound);
        }
    }
}
