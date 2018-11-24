﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using Videorama.Models;

namespace videorama.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult Customers()
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomers());
        }

        // GET: Admin/EditCustomer/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditCustomer(int id)
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomerDetail(id));
        }

        // POST: Admin/EditCustomer/5
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

        // GET: Admin/DeleteCustomer/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCustomer(int id)
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomerDetail(id));
        }

        // POST: Admin/DeleteCustomer/5
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

        // GET: Admin/Rents
        [Authorize(Roles = "Admin")]
        public ActionResult Rents()
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetRents());
        }

        // GET: Admin/RentDetails/5
        [Authorize(Roles = "Admin")]
        public ActionResult RentDetails(int idr)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetRentDetails(idr));
        }

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

        // GET: Admin/Stock
        [Authorize(Roles = "Admin")]
        public ActionResult Stock()
        {
            ProductsDb dbProduct = new ProductsDb();
            ModelState.Clear();
            return View(dbProduct.GetAllProducts());
        }

        // GET: Products/CreateProduct
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: Products/CreateProduct
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateProduct(FormCollection collection)
        {
            Product productForm = new Product();
            productForm.Title = Request.Form["Title"];
            productForm.Synopsis = Request.Form["Synopsis"];
            productForm.Price = Convert.ToDouble(Request.Form["Price"]);
            productForm.ReleaseDate = Convert.ToDateTime(Request.Form["ReleaseDate"]);
            productForm.Picture = Request.Form["Picture"];
            productForm.TypeP.IdType = Convert.ToInt32(Request.Form["IdType"]);
            productForm.Stock = Convert.ToInt32(Request.Form["Stock"]);
            productForm.Casting = new List<Person>();
            productForm.Categories = new List<Category>();


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

        // GET: Admin/EditStock/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditStock(int id)
        {
            ProductsDb dbProduct = new ProductsDb();
            ModelState.Clear();
            return View(dbProduct.GetAllProducts());
        }

        // POST: Admin/EditStock/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditStock(int id, FormCollection collection)
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

            if (customerValid)
            {
                return RedirectToAction("Customers");
            }
            else
            {
                return RedirectToAction("EditCustomer", id);
            }
        }

        // GET: Admin/DeleteProduct/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id)
        {
            CustomerDb dbCustomer = new CustomerDb();
            ModelState.Clear();
            return View(dbCustomer.GetCustomerDetail(id));
        }

        // POST: Admin/DeleteProduct/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int id, FormCollection collection)
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
    }
}
