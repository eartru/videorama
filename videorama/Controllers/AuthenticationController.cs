﻿using Microsoft.AspNet.Identity;
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
        /// <summary>
        /// Show register page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Save in DB data for a new account
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>View|Redirect</returns>
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

        /// <summary>
        /// Show login page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Send request to the DB to compare login and pwd
        /// with login and psw in the DB
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns>View|Redirect</returns>
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
                    // Authentication is OK, 
                    // Save the user data in an auth cookie
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFound.IdUser.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, model.UserName));
                    userClaims.Add(new Claim(ClaimTypes.UserData, ""));// Init a field for the product id, use it for the basket
                    if (userFound.IsAdmin)
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "User"));
                    }

                    // Save the auth cookie
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

        /// <summary>
        /// Logout the connected account
        /// </summary>
        /// <returns>Redirect</returns>
        [HttpGet]
        public ActionResult Logout()
        {
            // Remove all user data to the auth cookie
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}