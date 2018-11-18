using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using videorama.ViewModels;
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
        [HttpPost]
        public ActionResult SaveRegister(AuthenticationViewModel model)
        {
            CustomerDb dbCustomer = new CustomerDb();
            bool listProductFound;
            listProductFound = dbCustomer.AddCustomer(model.Customer);

            if (listProductFound)
            {
                return RedirectToAction("Login", "Authentication");
            } else
            {
                return RedirectToAction("Register", "Authentication");
            }
        }

        // GET: Show form to login
        public ActionResult Login()
        {
            return View();
        }



        // POST: Show form to create a new account
        [HttpPost]
        public ActionResult CheckLogin(AuthenticationViewModel model)
        {
            UserDb dbUser = new UserDb();
            User userFound;
            userFound = dbUser.GetUserByUserNameAndPassword(model.User);

            if (userFound.IdUser != 0)
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
    }
}