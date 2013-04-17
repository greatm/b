using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Security.Cryptography;

namespace b.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.Status = "404 Not Found";
            return View();
        }

        public ActionResult ServerError()
        {
            byte[] delay = new byte[1];
            RandomNumberGenerator prng = new RNGCryptoServiceProvider();

            prng.GetBytes(delay);
            Thread.Sleep((int)delay[0]);

            IDisposable disposable = prng as IDisposable;
            if (disposable != null) { disposable.Dispose(); }
            Response.Status = "500 Internal Server Error";
            return View();
        }
    }
}
