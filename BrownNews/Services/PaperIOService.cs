using System.Collections.Generic;
using System.IO;
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

        public bool CleanDir(string path)
        {
            path = Path.Combine(ContentRoot, path);
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
                return true;
            }
            return false;
        }

        public bool GetAllFromDir(string path, out List<SourceFile> sourceFiles)
        {
            try
            {
                path = Path.Combine(ContentRoot, path);
                sourceFiles = new List<SourceFile>();
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    sourceFiles.Add(
                        new SourceFile
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            Extension = Path.GetExtension(path),
                            FileBytes = File.ReadAllBytes(file)
                        }
                    );
                }
                return true;
            }
            catch
            {
                sourceFiles = new List<SourceFile>();
                return false;
            }
        }

        public bool SaveAllToDir(string path, List<SourceFile> sourceFiles)
        {
            try
            {
                path = Path.Combine(ContentRoot, path);
                Directory.CreateDirectory(path);
                foreach (var sFile in sourceFiles)
                {
                    var fPath = Path.Combine(path, sFile.Name + $".{sFile.Extension}");
                    File.WriteAllBytesAsync(fPath, sFile.FileBytes);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}