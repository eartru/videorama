using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using Videorama.Models;

namespace videorama.Controllers
{
    public class AdminController : Controller
    {

        /// <summary>
        /// Get all customers in database.
        /// Authorize only for administrator
        /// GET: Admin/Customers
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles ="Admin")]
        public ActionResult Customers()
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomers());
        }

        /// <summary>
        /// Get information about a customer by his ID in a form,
        /// so that the admin can edit knowing what was before.
        /// Authorize only for administrator
        /// GET: Admin/EditCustomer/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult EditCustomer(int id)
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomerDetail(id));
        }

        /// <summary>
        /// Send new information about a customer, edited in the view 
        /// and retrieve in a FormCollection.
        /// Authorize only for administrator
        /// POST: Admin/EditCustomer/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditCustomer(int id, FormCollection collection)
        {
            Customer customerForm = new Customer();
            customerForm.IdUser = id;
            customerForm.FirstName = Request.Form["FirstName"];
            customerForm.LastName = Request.Form["LastName"];
            customerForm.Email = Request.Form["Email"];
            customerForm.Address = Request.Form["Address"];
            customerForm.PostalCode = Request.Form["PostalCode"];
            customerForm.Town = Request.Form["Town"];
            customerForm.Country = Request.Form["Country"];

            CustomerDb dbCustomer = new CustomerDb();
            bool customerValid;
            customerValid = dbCustomer.UpdateCustomer(customerForm);

            if(customerValid)
            {
                return RedirectToAction("Customers");
            }
            else
            {
                return RedirectToAction("EditCustomer", id);
            }
        }

        /// <summary>
        /// Get information about a customer before deleting
        /// Authorize only for administrator
        /// GET: Admin/DeleteCustomer/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCustomer(int id)
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomerDetail(id));
        }

        /// <summary>
        /// Send request to delete a customer with his id in parameter.
        /// Authorize only for administrator
        /// POST: Admin/DeleteCustomer/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCustomer(int id, FormCollection collection)
        {

            CustomerDb dbCustomer = new CustomerDb();
            bool customerValid;
            customerValid = dbCustomer.DeleteCustomer(id);

            if (customerValid)
            {
                return RedirectToAction("Customers");
            }
            else
            {
                return RedirectToAction("DeleteCustomer", id);
            }
        }

        /// <summary>
        /// Get all rents which are currently in progress
        /// Authorize only for administrator
        /// GET: Admin/Rents
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Rents()
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetRents());
        }

        /// <summary>
        /// Get information about a rent by its id for any customer.
        /// Authorize only for administrator
        /// GET: Admin/RentDetails/id
        /// </summary>
        /// <param name="idr"></param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult RentDetails(int idr)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetRentDetails(idr));
        }

        /// <summary>
        /// Send a request to database to update the field inProgress for a rent by its ID,
        /// this will set inProgress to 0. 
        /// Authorize only for administrator
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="idRent"></param>
        /// <returns>RedirectToAction</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult ReturnBack(int idCustomer, int idRent)
        {
            RentDb dbRent = new RentDb();
            bool rentValid;
            rentValid = dbRent.UpdateRentReturnedBack(idRent);

            if (rentValid)
            {
                return RedirectToAction("Rents");
            }
            else
            {
                return RedirectToAction("RentDetails", new { idc = idCustomer, idr = idRent});
            }
        }

        /// <summary>
        /// Get all products in database to manage them.
        /// Authorize only for administrator
        /// GET: Admin/Stock
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Stock()
        {
            ProductsDb dbProduct = new ProductsDb();
            ModelState.Clear();
            return View(dbProduct.GetAllProducts());
        }

        /// <summary>
        /// Returns a view with a form to create a new product.
        /// Authorize only for administrator
        /// GET: Products/CreateProduct
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct()
        {
            return View();
        }

        /// <summary>
        /// Send a request to database to add a new product with the information from the form.
        /// The form contains a picture selected by the user on his desk and when the POST request
        /// is send, the picture is saved on the server at a specific path.
        /// Authorize only for administrator
        /// POST: Products/CreateProduct
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="Picture"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct(FormCollection collection, HttpPostedFileBase Picture)
        {
            if (Picture != null && Picture.ContentLength > 0)
            { 
                string path = Path.Combine(Server.MapPath("~/Content/Images/"),
                                           Path.GetFileName(Picture.FileName));
                Picture.SaveAs(path);
            }

            Product productForm = new Product()
            {
                Title = Request.Form["Title"],
                Synopsis = Request.Form["Synopsis"],
                Price = Convert.ToDecimal(Request.Form["Price"].Replace('.', ',')),
                ReleaseDate = Convert.ToDateTime(Request.Form["ReleaseDate"]),
                Picture = Request.Form["Picture"],
                    Stock = Convert.ToInt32(Request.Form["Stock"]),
                TypeP = new Videorama.Models.Type()
                {
                    IdType = Convert.ToInt32(Request.Form["IdType"])
                }
            };
 
            ProductsDb dbProduct = new ProductsDb();
            bool productValid;
            productValid = dbProduct.AddProduct(productForm);
            if (productValid)
            {
                return RedirectToAction("Stock");
            }
            else
            {
                return RedirectToAction("CreateProduct");
            }
        }

        /// <summary>
        /// Get information about a product by its ID in a form,
        /// so that the admin can edit knowing what was before.
        /// Authorize only for administrator
        /// GET: Admin/EditProduct/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int id)
        {
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();

            return View(dbProducts.GetProductsDetail(id));
        }

        /// <summary>
        /// Send edited information from the form to update a product in the database
        /// Authorize only for administrator
        /// POST: Admin/EditProduct/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int id, FormCollection collection)
        {
            var w = collection["Item1.Picture"];
            var wBis = Request.Form["Item1.Picture"];
            Product productForm = new Product()
            {
                IdProduct = id,
                Title = Request.Form["Item1.Title"],
                Synopsis = Request.Form["Item1.Synopsis"],
                Price = Convert.ToDecimal(Request.Form["Item1.Price"].Replace('.', ',')),
                ReleaseDate = Convert.ToDateTime(Request.Form["Item1.ReleaseDate"]),
                Picture = Request.Form["Item1.Picture"],
                Stock = Convert.ToInt32(Request.Form["Item1.Stock"]),
                TypeP = new Videorama.Models.Type()
                {
                    IdType = Convert.ToInt32(Request.Form["IdType"])
                }
            };

            ProductsDb dbProduct = new ProductsDb();
            bool productValid;
            productValid = dbProduct.UpdateProduct(productForm);
            if (productValid)
            {
                return RedirectToAction("Stock");
            }
            else
            {
                return RedirectToAction("EditProduct");
            }
        }

        /// <summary>
        /// Get information for a product by its id before deleting
        /// Authorize only for administrator
        /// GET: Admin/DeleteProduct/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id)
        {
            ProductsDb dbProduct = new ProductsDb();
            ModelState.Clear();
            return View(dbProduct.GetProductsDetail(id));
        }

        /// <summary>
        /// Send request to delete a product with its id in parameter.
        /// Authorize only for administrator
        /// POST: Admin/DeleteProduct/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id, FormCollection collection)
        {
            ProductsDb dbProduct = new ProductsDb();
            bool productValid;
            productValid = dbProduct.DeleteProduct(id);

            if (productValid)
            {
                return RedirectToAction("Stock");
            }
            else
            {
                return RedirectToAction("DeleteProduct", id);
            }
        }
    }
}
