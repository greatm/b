using System;
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
    public class MasterProductController : BaseController
    {
        public ActionResult Index()
        {
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
        }

        public ActionResult Details(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                if (ImageFile != null)
                {
                    ImageFile.InputStream.CopyTo(ms);
                    product.Image = ms.ToArray();
                }
            }
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Products.Max(t => t.ID) + 1;
                }
                catch { }
                product.ID = iId;
                product.Version = 1;
                product.EntryDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            if (product == null)
            {
                return HttpNotFound();
            }

            if (product.Image != null)
            {
                WebImage image = new WebImage(product.Image);
                ViewData["image"] = File(image.GetBytes(), "image/" + image.ImageFormat, image.FileName);
            }
            return View(product);
        }
        public FileContentResult GetProductImage(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            if (product == null || product.Image == null) return null;

            WebImage image = new WebImage(product.Image);
            if (image == null) return null;
            return File(image.GetBytes(), "image/" + image.ImageFormat, image.FileName);
        }
        //public FileContentResult GetProductImage(Product product)
        //{
        //    //Product product = db.Products.Find(id);
        //    if (product == null) return null;

        //    WebImage image = new WebImage(product.Image);
        //    return File(image.GetBytes(), "image/" + image.ImageFormat, image.FileName);
        //}

        //
        // POST: /MasterProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                if (ImageFile != null)
                {
                    ImageFile.InputStream.CopyTo(ms);
                    product.Image = ms.ToArray();
                }
            }
            if (ModelState.IsValid)
            {
                Product newItem = product;
                newItem.Version = product.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.Products.Add(newItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /MasterProduct/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
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
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            //Product product = db.Products.Find(id, version);
            //db.Products.Remove(product);
            var itemsToDelete = db.Products.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.Products.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}