using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using  Org.BouncyCastle;
using No1_Online.Data;

namespace No1_Online.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        private IHttpContextAccessor _httpContextAccessor;

        public ReportsController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;    
        }
        public IActionResult GeneratePDF()
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new PdfWriter(stream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);
                        document.Add(new Paragraph(_httpContextAccessor.HttpContext.Session.GetString("SelectedCompanyName")));
                    }
                }

                var content = stream.ToArray();
                return File(content, "application/pdf", "Report.pdf");
            }
        }
        public IActionResult Reports()
        {
            return PartialView("Reports");
        }
    }
}
