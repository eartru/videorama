using System;
using System.Web.Mvc;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    public class RentsController : Controller
    {
        // GET: Rents/Rents
        [Authorize(Roles = "User")]
        public ActionResult Rents(int id)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetDistinctRentByCustomer(id));
        }

        // GET: Rents/ViewPDF
        [Authorize(Roles = "User")]
        public ActionResult DownloadBill(int idR)
        {
            RentDb dbProducts = new RentDb();
            ModelState.Clear();
            BillViewModel model = dbProducts.GetRentDetails(idR);
            return new Rotativa.ViewAsPdf("ViewPDF", model);
        }
    }
}
