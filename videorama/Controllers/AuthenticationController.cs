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
        public ActionResult SaveRegister(string UserName, string FirstName, string Name, string Email, string Password, string Adress, string PostalCode, string Town, string Country)
        {
            if (Request.HttpMethod == "POST")
            {
                CustomerDb dbCustomer = new CustomerDb();
                Customer customer = new Customer(UserName, FirstName, Name, Email, Password, Adress, PostalCode, Town, Country);
                bool listProductFound;
                listProductFound = dbCustomer.AddCustomer(customer);

                if (listProductFound)
                {
                    return RedirectToAction("Login", "Authentication");
                } else
                {
                    return RedirectToAction("Register", "Authentication");
                }
                
            }
            else { 
                return View("Error");
            }
        }

        // GET: Show form to login
        public ActionResult Login()
        {
            return View();
        }

        

        // POST: Show form to create a new account
        public ActionResult CheckLogin(string UserName, string Password)
        {
            if (Request.HttpMethod == "POST")
            {
                UserDb dbUser = new UserDb();
                User userFound;
                userFound = dbUser.GetUserByUserNameAndPassword(UserName, Password);

                if (userFound.IdUser != 0)
                {
                    return RedirectToAction("Index", "Home");
                } else
                {
                    return RedirectToAction("Login", "Authentication");
                }
               
            }
            else
            {
                return View("Error");
            }
        }
    }
}