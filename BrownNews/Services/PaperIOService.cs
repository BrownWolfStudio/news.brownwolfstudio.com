using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BrownNews.Models;
using Microsoft.AspNetCore.Hosting;

namespace BrownNews.Services
{
    public class PaperIOService : IPaperIOService
    {
        public readonly string ContentRoot;

        public PaperIOService(IHostingEnvironment env)
        {
            ContentRoot = Path.Combine(env.ContentRootPath, "DownloadedPaper");
        }

        public (string, bool) GetFile(string path, string name)
        {
            var file = Path.Combine(ContentRoot, path, name);
            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                return (file, true);
            }
            else return (file, false);
        }

        public bool CleanDir(string path)
        {
            path = Path.Combine(ContentRoot, path);
            if (Directory.Exists(path)) Directory.Delete(path, true);
            Directory.CreateDirectory(path);
            return true;
        }
    }
}