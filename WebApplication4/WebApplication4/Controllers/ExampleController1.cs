﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{
    public class ExampleController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
