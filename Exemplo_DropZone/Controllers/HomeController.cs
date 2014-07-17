using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo_DropZone.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public void UploadFile()
        {
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    if (file != null && file.ContentLength > 0)
                    {
                        var originalDirectory = new DirectoryInfo(Server.MapPath(@""));
                        string pathString =  Path.Combine(originalDirectory.ToString(), "Files");

                        bool isExists = Directory.Exists(pathString);
                        if (!isExists)
                            Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
