using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System;

namespace AnimalShelter.Controllers
{
    public class CatController : Controller
    {
        [HttpGet("/cat")]
        public ActionResult Index()
        {
            List<Cat> allCats = Cat.GetAll();
            return View(allCats);
        }

        [HttpPost("/cat/sorted")]
        public ActionResult SortCats()
        {
            string column = Request.Form["column"];
            Console.WriteLine(column);
            List<Cat> allCats = Cat.SortBy(column);
            return View("Index", allCats);
        }
        //
        // [HttpGet("/cat/breed")]
        // public ActionResult Index()
        // {
        //     return View();
        // }
        //
        // [HttpGet("/cat/age")]
        // public ActionResult Index()
        // {
        //     return View();
        // }
        //
        // [HttpGet("/cat/date")]
        // public ActionResult Index()
        // {
        //     return View();
        // }
        //
        // [HttpGet("/cat/gender")]
        // public ActionResult Index()
        // {
        //     return View();
        // }
    }
}
