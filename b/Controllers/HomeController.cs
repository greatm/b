using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;

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

            //bDBContext db = new bDBContext();
            //db.whatsnews.LastOrDefault()
            //ViewBag.UpdateTime = DateTime.Now;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "info";

            return View();
        }
    }
}
