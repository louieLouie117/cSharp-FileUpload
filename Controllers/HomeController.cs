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

        public async Task<IActionResult> CrateApprentice(List<IFormFile> files, Apprentice FromFrom)
        {

            Console.WriteLine($"Apprentice Name: {FromFrom.name}");

            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    // full path to file in temp location
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/uploads", formFile.FileName); //we are using Temp file name just for the example. Add your own file path.
                    Console.WriteLine($"FileName: {formFile.FileName}");
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {

                        await formFile.CopyToAsync(stream);

                    }

                }
            }

            System.Console.WriteLine(new { count = files.Count, size, filePaths });
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return RedirectToAction("index");
        }
    }



}




