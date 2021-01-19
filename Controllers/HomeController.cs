using System;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;


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

        public IActionResult CrateApprentice(Apprentice FromForm)
        {

            Console.WriteLine("Button was click, New Apprentice was Created");


            return RedirectToAction("index");

        }

    }







}