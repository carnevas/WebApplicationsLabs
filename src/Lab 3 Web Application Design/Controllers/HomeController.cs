using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab4.Models;

namespace WebLab4.Controllers
{
    public class HomeController : Controller
    {
      
        //Gives greeting for home page
        public IActionResult Index()
        {
            IList<String> greetingMessage = new List<String>();
            var myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var time = TimeZoneInfo.ConvertTime(DateTime.Now, myTimeZone);
            String greeting = "Good Morning!";
            if (time.Hour >= 11 && time.Hour < 17)
            {
                greeting = "Good Afternoon!";
            }
            else if (time.Hour >= 17)
            {
                greeting = "Good Evening!";
            }
            ViewData["greeting"] = greeting;
            ViewData["timeOfDay"] = time.ToString("h:mm tt");
            ViewData["date"] = time.Date.ToString("D");
            ViewData["daysLeft"] = (365 - time.DayOfYear);
            ViewData["year"] = time.Year + 1;

            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
