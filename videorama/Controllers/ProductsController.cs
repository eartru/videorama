﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videorama.Models;

namespace videorama.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult ProductsList(int type)
        {
            ProductsDb dbProducts = new ProductsDb();
            ModelState.Clear();
            return View(dbProducts.GetProductsByType(type));
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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

        // GET: Products serach result
        public ActionResult ProductsSearchresult(List<Product> listProduct)
        {
            System.Diagnostics.Debug.WriteLine("hellooooooooo !");
            System.Diagnostics.Debug.WriteLine(listProduct);
            return View("~/Views/Products/PrductsList.cshtml");
        }
    }
}
