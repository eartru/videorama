using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        /// <summary>
        /// Show view with informations current loged account
        /// </summary>
        /// <returns>View|Redirect</returns>
        public ActionResult Detail()
        {
            CustomerDb dbCustomer = new CustomerDb();
            var claimIdentity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id > 0)
            {
                Customer customer = dbCustomer.GetCustomerDetail(id);
                AccountViewModel accountViewModel = new AccountViewModel
                {
                    IdUser = customer.IdUser,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    PostalCode = customer.PostalCode,
                    Town = customer.Town,
                    Country = customer.Country,
                    Email = customer.Email,
                    Username = customer.Username
                };

                return View(accountViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Show view to edit the current account
        /// </summary>
        /// <returns>View|Redirect</returns>
        public ActionResult Edit()
        {
            CustomerDb dbCustomer = new CustomerDb();
            var claimIdentity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id > 0)
            {
                Customer customer = dbCustomer.GetCustomerDetail(id);
                AccountViewModel accountViewModel = new AccountViewModel
                {
                    IdUser = customer.IdUser,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    PostalCode = customer.PostalCode,
                    Town = customer.Town,
                    Country = customer.Country,
                    Email = customer.Email,
                    Username = customer.Username
                };

                return View(accountViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Send data to the DB for update the account with new data
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns>Redirect</returns>
        [HttpPost]
        public ActionResult Edit(AccountViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDb dbCustomer = new CustomerDb();
                bool isCustomerEdited;
                
                Customer customer = new Customer
                {
                    IdUser = customerViewModel.IdUser,
                    FirstName = customerViewModel.FirstName,
                    LastName = customerViewModel.LastName,
                    Address = customerViewModel.Address,
                    PostalCode = customerViewModel.PostalCode,
                    Town = customerViewModel.Town,
                    Country = customerViewModel.Country,
                    Email = customerViewModel.Email,
                    Username = customerViewModel.Username
                };

                isCustomerEdited = dbCustomer.UpdateCustomer(customer);

                if (isCustomerEdited)
                {
                    var claimIdentity = User.Identity as ClaimsIdentity;
                    int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    if (id > 0)
                    {
                        return RedirectToAction("Detail", "Account");
                    }

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Show view to edit password current account
        /// </summary>
        /// <returns>View|Redirect</returns>
        public ActionResult EditPassword()
        {
            CustomerDb dbCustomer = new CustomerDb();
            var claimIdentity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id > 0)
            {
                PasswordViewModel passwordViewModel = new PasswordViewModel
                {
                    IdUser = id
                };

                return View(passwordViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Save the new password in the DB
        /// </summary>
        /// <param name="passwordViewModel"></param>
        /// <returns>Redirect</returns>
        [HttpPost]
        public ActionResult EditPassword(PasswordViewModel passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDb dbCustomer = new CustomerDb();
                bool isPasswordEdited;
                var w = passwordViewModel;

                isPasswordEdited = dbCustomer.UpdateCustomerPasword(passwordViewModel);

                if (isPasswordEdited)
                {
                    var claimIdentity = User.Identity as ClaimsIdentity;
                    int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    if (id > 0)
                    {
                        return RedirectToAction("Detail", "Account");
                    }

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// View to delete the current account
        /// </summary>
        /// <returns>View|Redirect</returns>
        public ActionResult Delete()
        {           
            var claimIdentity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (id > 0)
            {
                ViewData["Id"] = id;
                return View();
            }

            return RedirectToAction("Detail", "Account");
        }

        /// <summary>
        /// Remove the account in DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns>Redirect</returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            CustomerDb dbCustomer = new CustomerDb();
            bool customerValid;
            customerValid = dbCustomer.DeleteCustomer(Convert.ToInt32(collection["Id"]));

            if (customerValid)
            {
                return RedirectToAction("Register", "Authentication");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
