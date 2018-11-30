using System;
using System.Web.Mvc;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    public class RentsController : Controller
    {
        // GET: Rents/Rents
        [Authorize]
        public ActionResult Rents(int id)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetDistinctRentByCustomer(id));
        }

        // GET: Rents/ViewPDF
        [Authorize]
        public ActionResult DownloadBill(int idR)
        {
            RentDb dbProducts = new RentDb();
            ModelState.Clear();
            BillViewModel model = dbProducts.GetRentDetails(idR);
            return new Rotativa.ViewAsPdf("ViewPDF", model);
        }
        
        // GET: Select the date to return the location
        [Authorize]
        public ActionResult ChooseGetDate()
        {
            return View();
        }

        // GET: Select the date to return the location
        [Authorize]
        [HttpPost]
        public ActionResult AddRent(DateTime date)
        {
            RentDb dbRent = new RentDb();

            bool rent = dbRent.AddRent(date);

            return View();
        }
    }
}
