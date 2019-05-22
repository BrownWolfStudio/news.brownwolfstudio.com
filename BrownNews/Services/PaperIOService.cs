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

        public async Task<List<SourceFile>> GetAllFromDir(string path)
        {
            try
            {
                path = Path.Combine(ContentRoot, path);
                var sourceFiles = new List<SourceFile>();
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    sourceFiles.Add(
                        new SourceFile
                        {
                            Name = Path.GetFileNameWithoutExtension(file),
                            Extension = Path.GetExtension(path),
                            FileBytes = await File.ReadAllBytesAsync(file)
                        }
                    );
                }
                return sourceFiles;
            }
            catch
            {
                return new List<SourceFile>();
            }
        }

        public async Task<bool> SaveAllToDir(string path, List<SourceFile> sourceFiles)
        {
            try
            {
                path = Path.Combine(ContentRoot, path);
                Directory.CreateDirectory(path);
                foreach (var sFile in sourceFiles)
                {
                    var fPath = Path.Combine(path, sFile.Name + $".{sFile.Extension}");
                    await File.WriteAllBytesAsync(fPath, sFile.FileBytes);
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