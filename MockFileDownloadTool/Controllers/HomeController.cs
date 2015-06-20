using MockFileDownloadTool.Models;
using System.Collections.Specialized;
using System.Text;
using System.Web.Mvc;

namespace MockFileDownloadTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public FileContentHeadersResult GenerateFile(GenerateFileViewModel model)
        {
            var headers = new NameValueCollection();
            var filename = string.IsNullOrEmpty(model.filename) ? "foo.txt" : model.filename;
            var fileContent = string.IsNullOrEmpty(model.fileContent) ? "Hello World" : model.fileContent;
            var contentType = string.IsNullOrEmpty(model.contentType) ? "text/plain" : model.contentType;
            contentType = string.IsNullOrEmpty(model.customContentType) ? contentType : model.customContentType;    //override list if custom content type was entered

            string info = fileContent;
            byte[] data = Encoding.UTF8.GetBytes(info);
            if (!string.IsNullOrEmpty(model.HeaderName1) && !string.IsNullOrEmpty(model.HeaderValue1))
            {
                headers.Add(model.HeaderName1, model.HeaderValue1);
            }
            if (!string.IsNullOrEmpty(model.HeaderName2) && !string.IsNullOrEmpty(model.HeaderValue2))
            {
                headers.Add(model.HeaderName2, model.HeaderValue2);
            }
            if (!string.IsNullOrEmpty(model.HeaderName3) && !string.IsNullOrEmpty(model.HeaderValue3))
            {
                headers.Add(model.HeaderName3, model.HeaderValue3);
            }
            return new FileContentHeadersResult(data, contentType, filename, headers);
        }
    }

}