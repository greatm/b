﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;
using System.IO;
using System.Web.Helpers;

namespace b.Controllers
{
    public class MasterProductController : Controller
    {
        private bDBContext db = new bDBContext();

        //
        // GET: /MasterProduct/

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        //
        // GET: /MasterProduct/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /MasterProduct/Create

        public ActionResult Create()
        {
            return View(new Product());
        }

        //
        // POST: /MasterProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                //var files = Request.Files;
                ImageFile.InputStream.CopyTo(ms);
                product.Image = ms.ToArray();
            }
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /MasterProduct/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            WebImage image = new WebImage(product.Image);
            ViewData["image"] = File(image.GetBytes(), "image/" + image.ImageFormat, image.FileName);

            return View(product);
        }
        public FileContentResult GetProductImage(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null) return null;

            WebImage image = new WebImage(product.Image);
            return File(image.GetBytes(), "image/" + image.ImageFormat, image.FileName);
        }
     
        //
        // POST: /MasterProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                ImageFile.InputStream.CopyTo(ms);
                product.Image = ms.ToArray();
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /MasterProduct/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /MasterProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}