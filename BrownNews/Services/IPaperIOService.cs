using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BrownNews.Models;

namespace BrownNews.Services
{
    public interface IPaperIOService
    {
        bool CleanDir(string path);
        (string, bool) GetFile(string path, string name);
    }
}