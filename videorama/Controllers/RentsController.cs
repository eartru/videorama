using System;
using System.Web.Mvc;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    public class RentsController : Controller
    {
        /// <summary>
        /// Display the rents concerning the user connected
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public ActionResult Rents(int id)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetDistinctRentByCustomer(id));
        }

        /// <summary>
        /// Display a PDF with the information of the customer
        /// and the products for one rent selected.
        /// The PDF is open in a new tab from the rents page.
        /// Rotativa is a package to help displaying PDF.
        /// </summary>
        /// <param name="idR"></param>
        /// <returns></returns>
        public ActionResult DownloadBill(int idR)
        {
            RentDb dbProducts = new RentDb();
            ModelState.Clear();
            BillViewModel model = dbProducts.GetRentDetails(idR);
            return new Rotativa.ViewAsPdf("ViewPDF", model);
        }
    }
}
