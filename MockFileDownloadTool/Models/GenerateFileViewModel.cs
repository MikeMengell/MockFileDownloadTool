using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockFileDownloadTool.Models
{
    public class GenerateFileViewModel
    {
        public string filename { get; set; }
        public string fileContent { get; set; }
        public string contentType { get; set; }
        public string customContentType { get; set; }
        public string HeaderName1 { get; set; }
        public string HeaderValue1 { get; set; }
        public string HeaderName2 { get; set; }
        public string HeaderValue2 { get; set; }
        public string HeaderName3 { get; set; }
        public string HeaderValue3 { get; set; }
    }
}