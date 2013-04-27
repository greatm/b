using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.ViewModels;

namespace b.Controllers
{
    public class MasterCustomerController : Controller
    {
        //private Cu

        public ActionResult Index()
        {
            // return JavaScript("function hello(){alert(hello, world from js);}");
            return View();
        }

    }
}
