using System.Collections.Generic;
using BrownNews.Models;

namespace BrownNews.Services
{
    public interface IPaperIOService
    {
        bool SaveAllToDir(string path, List<SourceFile> sourceFiles);
        bool GetAllFromDir(string path, out List<SourceFile> sourceFiles);
        bool CleanDir(string path);
    }
}