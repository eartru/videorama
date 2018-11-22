using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using videorama.ViewModels;
using Videorama.Models;

namespace videorama.Controllers
{
    public class RentsController : Controller
    {
        public int idCustomer;
        public int idRent;

        // GET: Rents/Rents
        public ActionResult Rents(int id)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetDistinctRentByCustomer(id));
        }

        // GET: Rents/ViewPDF
        public ActionResult DownloadBill(int idC, int idR)
        {
            idCustomer = idC;
            idRent = idR;
            RentDb dbProducts = new RentDb();
            ModelState.Clear();
            BillViewModel model = dbProducts.GetRentDetails(idC, idR);
            return new Rotativa.ViewAsPdf("ViewPDF", model);
        }
    }
}
