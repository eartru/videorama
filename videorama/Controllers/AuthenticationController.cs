using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerDb dbCustomer = new CustomerDb();
                bool isCustomerCreated;
                isCustomerCreated = dbCustomer.AddCustomer(customer);

                if (isCustomerCreated)
                {
                    return RedirectToAction("Login", "Authentication");
                }

                return RedirectToAction("Register", "Authentication");
            }
            else
            {
                return View();
            }
        }

        // GET: Show form to login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Show form to create a new account
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserDb dbUser = new UserDb();
                User userFound;
                userFound = dbUser.GetUserByUserNameAndPassword(model.UserName, model.Password);

                if (userFound.IdUser != 0)
                {
                    // L'authentification est réussie, 
                    // injecter les infos utilisateur dans le cookie d'authentification :
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFound.IdUser.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, model.UserName));
                    if(userFound.IsAdmin)
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "User"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, DefaultAuthenticationTypes.ApplicationCookie);
                    var ctx = Request.GetOwinContext();
                    var authenticationManager = ctx.Authentication;
                    authenticationManager.SignIn(claimsIdentity);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}