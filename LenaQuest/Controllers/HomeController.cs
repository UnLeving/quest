using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LenaQuest.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.DotNet.PlatformAbstractions;

namespace LenaQuestQuest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
    }
}
