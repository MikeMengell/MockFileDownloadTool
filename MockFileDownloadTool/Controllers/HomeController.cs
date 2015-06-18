using MockFileDownloadTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MockFileDownloadTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult GenerateFile(GenerateFileViewModel model)
        {
            var filename = string.IsNullOrEmpty(model.filename) ? "foo.txt" : model.filename;
            var fileContent = string.IsNullOrEmpty(model.fileContent) ? "Hello World" : model.fileContent;
            var contentType = string.IsNullOrEmpty(model.contentType) ? "text/plain" : model.contentType;
            contentType = string.IsNullOrEmpty(model.customContentType) ? contentType : model.customContentType;    //override list of custom content type was entered

            string info = fileContent;
            byte[] data = Encoding.UTF8.GetBytes(info);
            if (!string.IsNullOrEmpty(model.HeaderName1) && !string.IsNullOrEmpty(model.HeaderValue1))
            {
                ControllerContext.HttpContext.Response.Headers.Add(model.HeaderName1, model.HeaderValue1);
            }
            if (!string.IsNullOrEmpty(model.HeaderName2) && !string.IsNullOrEmpty(model.HeaderValue2))
            {
                ControllerContext.HttpContext.Response.Headers.Add(model.HeaderName2, model.HeaderValue2);
            }
            if (!string.IsNullOrEmpty(model.HeaderName3) && !string.IsNullOrEmpty(model.HeaderValue3))
            {
                ControllerContext.HttpContext.Response.Headers.Add(model.HeaderName3, model.HeaderValue3);
            }
            var mockFile = File(data, contentType, filename);

            return mockFile;
        }
    }
}