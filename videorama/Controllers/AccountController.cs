using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using Videorama.Models;

namespace videorama.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // Show informations current loged account
        public ActionResult Detail()
        {
            CustomerDb dbCustomer = new CustomerDb();
            var claimIdentity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id > 0)
            {
                return View(dbCustomer.GetCustomerDetail(id));
            }

            return RedirectToAction("Index", "Home");
        }

        // Edit current account
        public ActionResult Edit()
        {
            CustomerDb dbCustomer = new CustomerDb();
            var claimIdentity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id > 0)
            {
                return View(dbCustomer.GetCustomerDetail(id));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
