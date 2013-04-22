using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.ReportViewer.Mvc;

namespace b.Controllers
{
    public class ReportCustomersController : Controller
    {
        //
        // GET: /ReportCustomers/

        public ActionResult Index()
        {
            return View();
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult ViewReport()
        //{
        //    ViewData["ReportModel"] = this.GetModel();
        //    ViewData["ProductName"] = "ReportViewer";
        //    return View();
        //}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ViewReport(ReportViewerParams param)
        {
            return new ReportViewerHtmlActionResult(this.GetModel(), param);
        }
        ReportViewerModel GetModel()
        {
            ReportViewerModel reportModel = new ReportViewerModel();
            reportModel.ReportPath = Server.MapPath("~/RDL/employee.rdl");
            return reportModel;
        }
    }
}
