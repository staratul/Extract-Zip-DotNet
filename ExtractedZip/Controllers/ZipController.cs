using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.Compression;

namespace ExtractedZip.Controllers
{
    public class ZipController : Controller
    {
        // GET: Zip
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtractZip(string zipFilePath, string extractToPath)
        {
            try
            {
                if (string.IsNullOrEmpty(zipFilePath) || string.IsNullOrEmpty(extractToPath))
                {
                    ViewBag.Message = "Both zip file path and extract to path are required.";
                    return View("Index");
                }

                if (!System.IO.File.Exists(zipFilePath))
                {
                    ViewBag.Message = "The specified zip file does not exist.";
                    return View("Index");
                }

                if (!Directory.Exists(extractToPath))
                {
                    Directory.CreateDirectory(extractToPath);
                }

                ZipFile.ExtractToDirectory(zipFilePath, extractToPath);
                ViewBag.Message = "Files extracted successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View("Index");
        }
    }
}