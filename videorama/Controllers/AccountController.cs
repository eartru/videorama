using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.Models;
using Videorama.Models;

namespace videorama.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [Authorize]
        public ActionResult Detail()
        {
            CustomerDb dbCustomer = new CustomerDb();
            int id = Convert.ToInt32(Session["IdUser"]);

            return View(dbCustomer.GetCustomerById(id));
        }

        
    }
}
