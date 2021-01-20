using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using System.Linq;
using System.Collections.Generic;

// system need for File upload
using System.IO;
using System.Threading.Tasks;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;

namespace FileUpload.Controllers
{

    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult index()
        {
            MainWrapper wMod = new MainWrapper();
            return View("index", wMod);
        }


        [HttpPost("CrateApprentice")]

        public async Task<IActionResult> CrateApprentice(List<IFormFile> files, Apprentice fForm)
        {



            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string timeStampMonth = DateTime.Now.Month.ToString("00");
                    string timeStampDay = DateTime.Now.Day.ToString("00");
                    string timeStampHour = DateTime.Now.Hour.ToString("00");
                    string timeStampMinutes = DateTime.Now.Minute.ToString("00");
                    string timeStampSeconds = DateTime.Now.Second.ToString("00");

                    string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";

                    // full path to file in temp location
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                     "wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}"); //we are using Temp file name just for the example. Add your own file path.

                    // for the db
                    Console.WriteLine($"Apprentice Name: {fForm.name}");
                    Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");

                    // string UploadName = $"FileName: {timeStamp}{formFile.FileName}";



                    string newName = $"{timeStamp}{formFile.FileName}";
                    fForm.UploadName = newName;




                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {



                        await formFile.CopyToAsync(stream);

                    }


                }


            }


            _context.Add(fForm);
            _context.SaveChanges();


            System.Console.WriteLine(new { count = files.Count, size, filePaths });
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return RedirectToAction("index");
        }
    }


}




