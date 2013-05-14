using b.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace b.Controllers
{
    public class MasterSubloactionController : Controller
    {
        private bDBContext db = new bDBContext();
        public ActionResult Index()
        {
            return View(db.Sublocations.Include(t => t.Store).ToList());
        }
        public ActionResult Details(int id = 0)
        {
            Sublocation sublocation = db.Sublocations.Find(id);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            return View(sublocation);
        }

        //
        // GET: /MasterSubloaction/Create

        public ActionResult Create()
        {
            CreateStoreDDitems(new Sublocation());
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        //
        // POST: /MasterSubloaction/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sublocation sublocation)
        {
            if (ModelState.IsValid)
            {
                db.Sublocations.Add(sublocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateStoreDDitems(sublocation);
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name");
            return View(sublocation);
        }

        //
        // GET: /MasterSubloaction/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sublocation sublocation = db.Sublocations.Find(id);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            CreateStoreDDitems(sublocation);
            return View(sublocation);
        }

        private void CreateStoreDDitems(Sublocation sublocation)
        {
            this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name", sublocation.StoreID);
        }

        //
        // POST: /MasterSubloaction/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sublocation sublocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sublocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateStoreDDitems(sublocation);
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name");
            return View(sublocation);
        }

        //
        // GET: /MasterSubloaction/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sublocation sublocation = db.Sublocations.Find(id);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            return View(sublocation);
        }

        //
        // POST: /MasterSubloaction/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sublocation sublocation = db.Sublocations.Find(id);
            db.Sublocations.Remove(sublocation);
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