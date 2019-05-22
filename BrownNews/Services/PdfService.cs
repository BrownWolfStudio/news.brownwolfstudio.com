using System.Collections.Generic;
using System.IO;
using CorePDF;
using CorePDF.Contents;
using CorePDF.Embeds;
using CorePDF.Pages;

namespace BrownNews.Services
{
    public class PdfService : IPdfService
    {
        public Document GetPdfFromImage(List<ImageFile> images)
        {
            var doc = new Document { Images = images };
            images.ForEach(i => doc.Pages.Add(new Page
            {
                PageSize = Paper.PAGEA4PORTRAIT,
                Contents = new List<Content>
                {
                    new Image
                    {
                        ImageName = i.Name,
                        Height = 842,
                        Width = 595
                    }
                }
            }));
            return doc;
        }
    }
}