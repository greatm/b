using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.ReportViewer.Mvc;
//using MvcReportViewer.Models;
using Syncfusion.Reports.Mvc;

namespace b.Controllers
{
    public class ReportSalesController : Controller
    {
        ReportViewerModel model;
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

        ReportViewerModel GetModel()
        {
            ReportViewerModel reportModel = new ReportViewerModel();
            reportModel.ReportPath = Server.MapPath("~/App_Data/ParameterReport.rdl");
            return reportModel;
        }

        [HttpPost]
        public ActionResult ReportAction(ReportViewerParams parameter)
        {
            model = new ReportViewerModel();
            model.ReportPath = Server.MapPath("~/App_Data/ParameterReport.rdl");
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
    }
}
