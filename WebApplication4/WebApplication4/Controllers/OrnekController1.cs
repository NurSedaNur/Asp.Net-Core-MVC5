using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }



    public class OrnekController1 : Controller
    {
        public IActionResult Index()
        {
            var productList = new List<Product>()
            {
                new(){Id=1,Name="kalem"},
                new(){Id=2,Name="defter"},
                new(){Id=3,Name="silgi"}
            };


            ViewBag.name = "Asp.Net Core";

            ViewData["age"] = 30;

            return View(productList);
        }

        public IActionResult Index2()
        {

            //veritabanı kaydetme islemleri

            return RedirectToAction("Index", "OrnekController1");

            //return View();
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "OrnekController1", new { id = id });
        }
        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id});
        }




        public IActionResult ContentResult()
        {
            return Content("contentResult");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "kalem 1", price = 100 });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }


    }


}
