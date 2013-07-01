using b.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace b.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "welcome";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "us";

            bDBContext db = new bDBContext();
            var whats = db.whatsnews.OrderByDescending(t => t.WorkTime).ToList();
            return View(whats);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "info";

            return View();
        }

        public ActionResult DailyDeal()
        {
            var album = GetDailyDeal();
            return PartialView("_DailyDeal", album);
        }
        private Product GetDailyDeal()
        {
            bDBContext db = new bDBContext();
            return db.Products
            .OrderBy(a => a.Name)
            .First();
        }

        public ActionResult ProductSearch(string q)
        {
            var products = GetProducts(q);
            return PartialView("/MasterProduct/Index", products);
        }
        private List<Product> GetProducts(string searchString)
        {
            bDBContext db = new bDBContext();
            return db.Products
            .Where(a => a.Name.Contains(searchString))
            .ToList();
        }
    }
}
