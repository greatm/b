using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.ReportViewer.Mvc;
using Syncfusion.Reports.Mvc;

namespace b.Controllers
{
    public class ReportUsersController : Controller
    {
        ReportViewerModel model { get; set; }

        public ActionResult ViewReport()
        {
            ViewData["ReportModel"] = this.GetModel();
            ViewData["ProductName"] = "ReportViewer";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ViewReport(ReportViewerParams param)
        {
            return new ReportViewerHtmlActionResult(this.GetModel(), param);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(ReportViewerParams parameter)
        {
            //this.Session["InvoiceID"] = parameter.InvoiceID;
            return View(model);
        }

        [HttpPost]
        public ActionResult ReportAction(ReportViewerParams parameter)
        {
            model = new ReportViewerModel();
            model.ReportPath = Server.MapPath("~/RDL/employee.rdl");
            if (Session["InvoiceID"] != null)
            {
                List<ReportParameter> parameters = new List<ReportParameter>();
                ReportParameter param = new ReportParameter();
                param.Labels.Add(Session["InvoiceID"].ToString());
                param.Values.Add(Session["InvoiceID"].ToString());
                param.Name = "InvoiceID";
                parameters.Add(param);
                model.Parameters = parameters;
            }
            return new ReportViewerHtmlActionResult(model, parameter);
        }
        ReportViewerModel GetModel()
        {
            model = new ReportViewerModel();
            model.ReportPath = Server.MapPath("~/App_Data/employee.rdl");
            return model;
        }
    }
}
