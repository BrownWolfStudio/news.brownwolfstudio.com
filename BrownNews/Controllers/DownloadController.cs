using BrownNews.Services;
using BrownNews.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IDownloadNewsPaperService _downloadNewsPaperService;

        public DownloadController(IDownloadNewsPaperService downloadNewsPaperService)
        {
            _downloadNewsPaperService = downloadNewsPaperService;
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
            return File(files.ZipIt(), "application/zip", $"{nameof(GujaratSamachar)}-{DateTime.Now.ToString("ddMMyyyy")}.zip");
        }

        public async Task<IActionResult> DivyaBhaskarRajkot()
        {
            var files = await _downloadNewsPaperService.GetDbRkFilesAsync();
            return File(files.ZipIt(), "application/zip", $"{nameof(DivyaBhaskarRajkot)}-{DateTime.Now.ToString("ddMMyyyy")}.zip");
        }
    }
}
