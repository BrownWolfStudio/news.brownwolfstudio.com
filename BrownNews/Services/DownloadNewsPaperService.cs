using BrownNews.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrownNews.Services
{
    public class DownloadNewsPaperService : IDownloadNewsPaperService
    {
        private readonly IHttpClientFactory _clientFactory;

        private int Page { get; set; }
        private string City { get; set; } = "RAJ";

        private string GsRkUrlFormat { get; set; } = "http://enewspapr.com/News/GUJARAT/{0}/{1:yyyy}/{2:MM}/{3:dd}/{4:yyyyMMdd}_{5}.jpg";
        public string GsRkCurrentUrl
        {
            get
            {
                var date = DateTime.Now;
                return string.Format(GsRkUrlFormat, City, date, date, date, date, Page);
            }
        }

        private string DbRkUrlFormat { get; set; } = "http://digitalimages.bhaskar.com/gujarat/epaperimages/{0:ddMMyyyy}/{1}rajkot%20city-pg{2}-0ll.jpg";
        public string DbRkCurrentUrl
        {
            get
            {
                var date = DateTime.Now;
                return string.Format(DbRkUrlFormat, date, date.Day - 1, Page);
            }
        }

        public DownloadNewsPaperService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<SourceFile>> GetGsFilesAsync(string city)
        {
            Page = 1;
            City = city;
            List<SourceFile> sourceFiles = new List<SourceFile>();
            var url = GsRkCurrentUrl;
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(url);
            while (response.IsSuccessStatusCode)
            {
                var source = new SourceFile { Name = $"GujaratSamachar-{Page}", Extension = "jpg", FileBytes = await response.Content.ReadAsByteArrayAsync() };
                sourceFiles.Add(source);
                Page++;
                url = GsRkCurrentUrl;
                response = await Client.GetAsync(url);
            }

            return sourceFiles;
        }

        public async Task<List<SourceFile>> GetDbRkFilesAsync()
        {
            Page = 1;
            List<SourceFile> sourceFiles = new List<SourceFile>();
            var url = DbRkCurrentUrl;
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(url);
            while (response.IsSuccessStatusCode)
            {
                var source = new SourceFile { Name = $"DivyaBhaskar-{Page}", Extension = "jpg", FileBytes = await response.Content.ReadAsByteArrayAsync() };
                sourceFiles.Add(source);
                Page++;
                url = DbRkCurrentUrl;
                response = await Client.GetAsync(url);
            }

            return sourceFiles;
        }
    }
}
