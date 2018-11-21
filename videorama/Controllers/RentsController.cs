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

        // GET: Rents/MyRents
        public ActionResult Rents(int id)
        {
            RentDb dbRent = new RentDb();
            ModelState.Clear();
            return View(dbRent.GetDistinctRentByCustomer(id));
        }

        // GET: Rents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rents/ViewPDF
        public ActionResult DownloadBill(int idC, int idR)
        {
            idCustomer = idC;
            idRent = idR;
            RentDb dbProducts = new RentDb();
            ModelState.Clear();
            BillViewModel model = dbProducts.GetRentDetailsForBill(idC, idR);
            return new Rotativa.ViewAsPdf("ViewPDF", model);
        }
        
        // POST: Rents/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rents/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rents/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
