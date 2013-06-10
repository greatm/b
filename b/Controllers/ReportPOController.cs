using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.pdf;
using b.Models;
using b.ViewModels;

namespace b.Controllers
{
    public class ReportPOController : PdfViewController
    {
        public ActionResult PrintPO()
        {
            var poes = rb.All<PurchaseOrder>().ToList();
            return this.ViewPdf("Purchase Order Report", "PrintPO", poes);
        }
    }
}
