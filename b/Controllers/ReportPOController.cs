using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.pdf;
using b.Models;
using b.ViewModels;
using MvcJqGrid;

namespace b.Controllers
{
    public class ReportPOController : RepoBaseController //PdfViewController
    {
        public ActionResult PrintPOgrid()
        {
            return View();
        }
        public ActionResult poGrid(GridSettings grid)
        {

            //IRepositoryUser _repository = new IRepositoryUser();
            //var query = _repository.Users();
            var query = rb.AllV<PurchaseOrder>();

            //sorting
            query = query.OrderBy<PurchaseOrder>(grid.SortColumn, grid.SortOrder);

            //count
            var count = query.Count();

            //paging
            var data = query.Skip((grid.PageIndex - 1) * grid.PageSize).Take(grid.PageSize).ToArray();

            var result = new
            {
                total = (int)Math.Ceiling((double)count / grid.PageSize),
                page = grid.PageIndex,
                records = count,
                rows = (from curPO in data
                        select new
                        {
                            ID = curPO.ID.ToString(),
                            Vendor = curPO.Vendor == null ? "" : curPO.Vendor.Name,
                            POItems = curPO.POItems,
                        }).ToArray()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult PrintPO()
        //{
        //    var poes = rb.All<PurchaseOrder>().ToList();
        //    return this.ViewPdf("Purchase Order Report", "PrintPO", poes);
        //}
    }
}
