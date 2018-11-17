using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using Videorama.Models;

namespace videorama.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Show form to create a new account
        public ActionResult Register()
        {
            return View();
        }
        
        // POST: Show form to create a new account
        public ActionResult SaveRegister(string FirstName, string Name, string Email, string Password, string Adress, string PostalCode, string Town, string Country)
        {
            if (Request.HttpMethod == "POST")
            {
                CustomerDb dbCustomer = new CustomerDb();
                Customer customer = new Customer(FirstName, Name, Email, Password, Adress, PostalCode, Town, Country);
                bool listProductFound;
                listProductFound = dbCustomer.AddCustomer(customer);

                return RedirectToAction("Index", "Home");
            }
            else { 
                return View("Error");
            }
        }
    }
}