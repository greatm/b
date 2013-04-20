using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.ReportViewer.Mvc;

namespace Reports.Controllers
{
    public class ReportCustomersController : Controller
    {
        //
        // GET: /ReportCustomers/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewReport()
        {
            ViewData["ReportModel"] = this.GetModel();
            ViewData["ProductName"] = "ReportViewer";
            return View();
        }
        ReportViewerModel GetModel()
        {
            ReportViewerModel reportModel = new ReportViewerModel();
            reportModel.ReportPath = Server.MapPath("~/App_Data/employee.rdl");
            return reportModel;
        }
    }
}
