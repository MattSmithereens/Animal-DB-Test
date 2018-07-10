using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System;

namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
        [HttpPost("/animal")]
        public ActionResult Index()
        {
            string type = Request.Form["type"];
            string column = Request.Form["column"];
            List<Animal> allAnimals = Animal.SortBy(type, column);
            return View(allAnimals);
        }

        [HttpPost("/animal/sorted")]
        public ActionResult SortAnimals()
        {
            string type = Request.Form["type"];
            string column = Request.Form["column"];
            List<Animal> allAnimals = Animal.SortBy(type, column);
            return View("Index", allAnimals);
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
