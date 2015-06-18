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

        public FileContentResult GenerateFile(string filename, string fileContent, string contentType, string customContentType)
        {
            filename = string.IsNullOrEmpty(filename) ? "foo.txt" : filename;
            fileContent = string.IsNullOrEmpty(fileContent) ? "Hello World" : fileContent;
            contentType = string.IsNullOrEmpty(contentType) ? "text/plain" : contentType;
            contentType = string.IsNullOrEmpty(customContentType) ? contentType : customContentType;    //override list of custom content type was entered

            string info = fileContent;
            byte[] data = Encoding.UTF8.GetBytes(info);
            return File(data, contentType, filename);
        }
    }
}