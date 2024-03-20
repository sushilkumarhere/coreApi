using ExcelDataReader;
using exceltosql.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

using Microsoft.EntityFrameworkCore;
using System.Text;

namespace exceltosql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string filePath;
        private object rel2Context;
        private readonly Medisuite_rel2Context _context;


        public HomeController(ILogger<HomeController> logger, Medisuite_rel2Context rel2Context)
        {
            _logger = logger;
            _context = rel2Context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult UploadExcel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (file != null && file.Length > 0)  
            {
                var uploadfolder = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";
                if(!Directory.Exists(uploadfolder)) 
                {
                    Directory.CreateDirectory(uploadfolder);
                }
                var filePath=Path.Combine(uploadfolder, file.FileName);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    await file .CopyToAsync(stream);

                }
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            bool isHeaderSkipped =false;
                            while (reader.Read())
                            {
                                if(!isHeaderSkipped)
                                {
                                    isHeaderSkipped = true;
                                    continue;
                                }
                                his_icd_diagnosis hc = new his_icd_diagnosis();
                                hc.IcdCode = reader.GetValue(0).ToString();
                                hc.LD = reader.GetValue(1).ToString();
                                
                                _context.Add(hc);
                                await  _context.SaveChangesAsync();                           
                          
                            }
                        } while (reader.NextResult());

                        ViewBag.Massage = "success";
                    }
                }

            }
            else
                ViewBag.Massage = "Empty";

            return View();
        }
    }
}