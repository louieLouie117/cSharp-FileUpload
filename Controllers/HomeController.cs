using System;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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
            return View("index");
        }

    }







}