using BrownNews.Services;
using BrownNews.Utilities;
using CorePDF.Embeds;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IDownloadNewsPaperService _downloadNewsPaperService;
        private readonly IPdfService _pdfService;

        public DownloadController(IDownloadNewsPaperService downloadNewsPaperService, IPdfService pdfService)
        {
            _downloadNewsPaperService = downloadNewsPaperService;
            _pdfService = pdfService;
        }

        [Route("/download")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> GujaratSamachar(string city)
        {
            var files = await _downloadNewsPaperService.GetGsFilesAsync(city);
            List<ImageFile> images = new List<ImageFile>();
            files.ForEach(f => images.Add(new ImageFile { FileData = f.FileBytes, Name = f.Name }));
            var doc = _pdfService.GetPdfFromImage(images);
            using (var stream = new MemoryStream())
            {
                doc.Publish(stream);
                return File(stream.ToArray(), "application/pdf", $"{nameof(GujaratSamachar)}-{DateTime.Now.ToString("ddMMyyyy")}.pdf");
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
