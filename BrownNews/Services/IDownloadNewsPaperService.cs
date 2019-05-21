using BrownNews.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrownNews.Services
{
    public interface IDownloadNewsPaperService
    {
        Task<List<SourceFile>> GetGsFilesAsync(string city);
        Task<List<SourceFile>> GetDbRkFilesAsync();
    }
}
