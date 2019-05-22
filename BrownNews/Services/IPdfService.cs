using System.Collections.Generic;
using System.IO;
using BrownNews.Models;
using CorePDF;
using CorePDF.Embeds;

namespace BrownNews.Services
{
    public interface IPdfService
    {
        Document GetPdfFromImage(List<SourceFile> files);
    }
}