using BrownNews.Services;
using BrownNews.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IDownloadNewsPaperService _downloadNewsPaperService;
        private readonly IPdfService _pdfService;
        private readonly IPaperIOService _paperIOService;

        public DownloadController(IDownloadNewsPaperService downloadNewsPaperService, IPdfService pdfService, IPaperIOService paperIOService)
        {
            _downloadNewsPaperService = downloadNewsPaperService;
            _pdfService = pdfService;
            _paperIOService = paperIOService;
        }

        [Route("/download")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> GujaratSamachar(string city)
        {
            string file, name = $"{DateTime.Now.ToString("ddMMyyyy")}-{city}.pdf";
            bool result;
            (file, result) = _paperIOService.GetFile(nameof(GujaratSamachar), name);
            if (result)
            {
                return PhysicalFile(file, "application/pdf", Path.GetFileName(file));
            }
            else
            {
                var files = await _downloadNewsPaperService.GetGsFilesAsync(city);
                var doc = _pdfService.GetPdfFromImage(files);
                result = false;
                result = _paperIOService.CleanDir(nameof(GujaratSamachar));
                using (var stream = System.IO.File.Create(file))
                {
                    doc.Publish(stream);
                }
                if (result) return PhysicalFile(file, "application/pdf", Path.GetFileName(file));
                else return NotFound();
            }
            // return File(files.ZipIt(), "application/zip", $"{nameof(GujaratSamachar)}-{DateTime.Now.ToString("ddMMyyyy")}.zip");
        }

        public async Task<IActionResult> DivyaBhaskarRajkot()
        {
            var files = await _downloadNewsPaperService.GetDbRkFilesAsync();
            return File(files.ZipIt(), "application/zip", $"{nameof(DivyaBhaskarRajkot)}-{DateTime.Now.ToString("ddMMyyyy")}.zip");
        }
    }
}
