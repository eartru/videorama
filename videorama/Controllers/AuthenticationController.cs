using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult Register(AuthenticationViewModel model)
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
        public ActionResult Login(AuthenticationViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserDb dbUser = new UserDb();
                User userFound;
                userFound = dbUser.GetUserByUserNameAndPassword(model.User);

                if (userFound.IdUser != 0)
                {
                    FormsAuthentication.SetAuthCookie(userFound.IdUser.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        string currentUserId = User.Identity.Name;
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        string currentUserId = User.Identity.Name;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}