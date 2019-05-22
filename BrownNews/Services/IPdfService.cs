using System.Collections.Generic;
using System.IO;
using CorePDF;
using CorePDF.Embeds;

namespace BrownNews.Services
{
    public interface IPdfService
    {
        Document GetPdfFromImage(List<ImageFile> images);
    }
}