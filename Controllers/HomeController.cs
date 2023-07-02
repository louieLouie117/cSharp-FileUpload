using System;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using System.Linq;
using System.Collections.Generic;



// system need for File upload
using System.IO;
using System.Threading.Tasks;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;
using Microsoft.AspNetCore.Hosting;


namespace FileUpload.Controllers
{

    public class HomeController : Controller
    {
        private MyContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("")]
        public IActionResult index()
        {
            MainWrapper wMod = new MainWrapper();
            ViewBag.ApprenticeList = _context.Apprentices.ToList();

            return View("index", wMod);
        }




        [HttpPost("UploadImage")]

        public async Task<IActionResult> UploadImage(List<IFormFile> files, Apprentice fForm)
        {

            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // TimeStamp
                    string timeStampMonth = DateTime.Now.Month.ToString("00");
                    string timeStampDay = DateTime.Now.Day.ToString("00");
                    string timeStampHour = DateTime.Now.Hour.ToString("00");
                    string timeStampMinutes = DateTime.Now.Minute.ToString("00");
                    string timeStampSeconds = DateTime.Now.Second.ToString("00");

                    string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";

                    //Place to save file
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                     "wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}");

                    // for the db
                    Console.WriteLine($"Apprentice Name: {fForm.name}");
                    Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");

                    // Assign name to be saved to the db
                    string newName = $"{timeStamp}{formFile.FileName}";
                    fForm.UploadName = newName;


                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // add to data base
            _context.Add(fForm);
            _context.SaveChanges();

            System.Console.WriteLine(new { count = files.Count, size, filePaths });
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return RedirectToAction("index");
        }



        [HttpPost("ServerFileUploader")]

        public async Task<IActionResult> ServerFileUploader(List<IFormFile> files, Apprentice fForm)
        {

            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // TimeStamp
                    string timeStampMonth = DateTime.Now.Month.ToString("00");
                    string timeStampDay = DateTime.Now.Day.ToString("00");
                    string timeStampHour = DateTime.Now.Hour.ToString("00");
                    string timeStampMinutes = DateTime.Now.Minute.ToString("00");
                    string timeStampSeconds = DateTime.Now.Second.ToString("00");

                    string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";

                    //Place to save file
                    string folderPath = $"img/uploads/";
                    folderPath += timeStamp + formFile.FileName;

                    System.Console.WriteLine($"******folder path name {folderPath}");
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                    // Assign name to be saved to the db
                    string newName = $"{timeStamp}{formFile.FileName}";
                    fForm.UploadName = newName;


                    filePaths.Add(serverFolder);
                    using (var stream = new FileStream(serverFolder, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);

                    }
                    // await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));



                }
            }

            // add to data base
            _context.Add(fForm);
            _context.SaveChanges();

            System.Console.WriteLine(new { count = files.Count, size, filePaths });
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return RedirectToAction("index");
        }


        // [HttpPost("UploadFileAsync")]
        // public async Task<JsonResult> UploadFileAsync(List<IFormFile> files, Apprentice fForm)
        // {

        //     long size = files.Sum(f => f.Length);

        //     var filePaths = new List<string>();

        //     System.Console.WriteLine("New Method to upload images write by AI");
        //     foreach (var formFile in files)
        //     {
        //         if (formFile.Length > 0)
        //         {
        //             // TimeStamp
        //             string timeStampMonth = DateTime.Now.Month.ToString("00");
        //             string timeStampDay = DateTime.Now.Day.ToString("00");
        //             string timeStampHour = DateTime.Now.Hour.ToString("00");
        //             string timeStampMinutes = DateTime.Now.Minute.ToString("00");
        //             string timeStampSeconds = DateTime.Now.Second.ToString("00");

        //             string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";

        //             //Place to save file
        //             var filePath = Path.Combine(Directory.GetCurrentDirectory(),
        //              "wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}");

        //             // for the db
        //             Console.WriteLine($"Apprentice Name: {fForm.name}");
        //             Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");

        //             // Assign name to be saved to the db
        //             string newName = $"{timeStamp}{formFile.FileName}";
        //             fForm.UploadName = newName;


        //             filePaths.Add(filePath);
        //             using (var stream = System.IO.File.Create(filePath))
        //             {
        //                 await formFile.CopyToAsync(stream);
        //             }

        //         }
        //     }

        //     // Add your logic here to process the Apprentice object

        //     // add to data base
        //     _context.Add(fForm);
        //     _context.SaveChanges();

        //     System.Console.WriteLine(new { count = files.Count, size, filePaths });

        //     return Json(new { success = true, message = "Files uploaded successfully" });
        // }











        // [HttpPost("UploadFile")]
        // public JsonResult UploadFile(List<IFormFile> files, Apprentice fForm)
        // {

        //     long size = files.Sum(f => f.Length);

        //     var filePaths = new List<string>();

        //     System.Console.WriteLine("New Method to upload images");
        //     foreach (var formFile in files)
        //     {
        //         if (formFile.Length > 0)
        //         {
        //             // TimeStamp
        //             string timeStampMonth = DateTime.Now.Month.ToString("00");
        //             string timeStampDay = DateTime.Now.Day.ToString("00");
        //             string timeStampHour = DateTime.Now.Hour.ToString("00");
        //             string timeStampMinutes = DateTime.Now.Minute.ToString("00");
        //             string timeStampSeconds = DateTime.Now.Second.ToString("00");

        //             string timeStamp = $"{timeStampMonth}{timeStampDay}{timeStampHour}{timeStampMinutes}{timeStampSeconds}";

        //             //Place to save file
        //             var filePath = Path.Combine("wwwroot/img/uploads", $"{timeStamp}{formFile.FileName}");

        //             // for the db
        //             Console.WriteLine($"Apprentice Name: {fForm.name}");
        //             Console.WriteLine($"FileName: {timeStamp}{formFile.FileName}");

        //             // Assign name to be saved to the db
        //             string newName = $"{timeStamp}{formFile.FileName}";
        //             fForm.UploadName = newName;


        //             filePaths.Add(filePath);
        //             using (var stream = System.IO.File.Create(filePath))
        //             {
        //                 formFile.CopyTo(stream);
        //             }


        //         }
        //     }

        //     // Add your logic here to process the Apprentice object

        //     // add to data base
        //     _context.Add(fForm);
        //     _context.SaveChanges();

        //     System.Console.WriteLine(new { count = files.Count, size, filePaths });

        //     return Json(new { success = true, message = "Files uploaded successfully" });
        // }


        // [HttpPost("FileUploader")]

        // public async Task<IActionResult> FileUploader(List<IFormFile> files)
        // {

        //     System.Console.WriteLine("You have reached the backend of file Uploader");
        //     long size = files.Sum(f => f.Length);

        //     foreach (var formFile in files)
        //     {
        //         if (formFile.Length > 0)
        //         {
        //             var filePath = Path.GetTempFileName();
        //             System.Console.WriteLine($"Name {filePath}");

        //             using (var stream = System.IO.File.Create(filePath))
        //             {
        //                 await formFile.CopyToAsync(stream);
        //             }
        //         }
        //     }

        //     // Process uploaded files
        //     // Don't rely on or trust the FileName property without validation.

        //     return Ok(new { count = files.Count, size });
        // }





        [HttpPost("DeleteImage")]
        public JsonResult DeleteImage(MainWrapper FromForm)
        {
            System.Console.WriteLine($"reach backend of delete image {FromForm.Apprentice.ApprenticeId}");

            var ImageId = (int)FromForm.Apprentice.ApprenticeId;

            Apprentice GetImage = _context.Apprentices.FirstOrDefault(lr => lr.ApprenticeId == ImageId);


            _context.Apprentices.Remove(GetImage);
            _context.SaveChanges();

            return Json(new { success = true, message = "Image deleted successfully" });
        }







        // end

    }


}




