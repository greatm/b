using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Controllers;

namespace b.pdf
{
    public class PdfViewController : BaseController2
    {
        private readonly HtmlViewRenderer htmlViewRenderer;
        private readonly StandardPdfRenderer standardPdfRenderer;
        public PdfViewController()
        {
            this.htmlViewRenderer = new HtmlViewRenderer();
            this.standardPdfRenderer = new StandardPdfRenderer();
        }
        protected ActionResult ViewPdf(string pageTitle, string viewName, object model)
        {
            // Render the view html to a string.
            string htmlText = this.htmlViewRenderer.RenderViewToString(this, viewName, model);

            // Let the html be rendered into a PDF document through iTextSharp.
            byte[] buffer = standardPdfRenderer.Render(htmlText, pageTitle);

            // Return the PDF as a binary stream to the client.
            return new BinaryContentResult(buffer, "application/pdf");
        }
    }
}
