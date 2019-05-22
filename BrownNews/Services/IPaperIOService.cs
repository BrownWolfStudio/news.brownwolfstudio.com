using System.Collections.Generic;
using System.Threading.Tasks;
using BrownNews.Models;

namespace BrownNews.Services
{
    public interface IPaperIOService
    {
        Task<bool> SaveAllToDir(string path, List<SourceFile> sourceFiles);
        Task<List<SourceFile>> GetAllFromDir(string path);
        bool CleanDir(string path);
    }
}