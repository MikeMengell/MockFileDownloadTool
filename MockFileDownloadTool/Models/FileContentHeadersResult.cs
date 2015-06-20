using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockFileDownloadTool.Models
{
    public class FileContentHeadersResult : FileContentResult
    {
        private NameValueCollection _headers;
        public FileContentHeadersResult(byte[] fileContents, string contentType, string fileDownloadName, NameValueCollection headers) : base(fileContents, contentType)
        {
            _headers = headers;
            base.FileDownloadName = fileDownloadName;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            response.Headers.Add(_headers);
            base.WriteFile(response);
        }
    }
}