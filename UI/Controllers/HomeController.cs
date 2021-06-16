using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysMatur.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.facebook = true;
            ViewBag.reddit = false;
            ViewBag.feed = new List<Dictionary<string,string>>() { new Dictionary<string, string>() { { "Source", "Facebook" }, { "Username", "VeVerča" }, { "Date", "11.6.2021" }, {"Text","PŘeNoc bude!" } },
                                                                   new Dictionary<string, string>() { { "Source", "Facebook" }, { "Username", "VeVerča" }, { "Date", "11.6.2021" }, {"Text","PŘeNoc bude!" } }};
            return View();
        }
    }
}
