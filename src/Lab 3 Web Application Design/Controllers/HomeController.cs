using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab_3_Web_Application_Design.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetGreeting()
        {
            IList<String> greetingMessage = new List<String>();
            DateTime time = DateTime.Now;
            String greeting = "Good Morning!";
            if(time.Hour > 12 && time.Hour < 6)
            {
                greeting = "Good Afternoon!";
            }
            else if(time.Hour > 6)
            {
                greeting = "Good Evening!";
            }
            ViewData["greeting"] = greeting;
            ViewData["timeOfDay"] = time.TimeOfDay;
            ViewData["date"] = DateTime.Today.ToString("D");
            ViewData["daysLeft"] = (365 - time.DayOfYear);
            ViewData["year"] = time.Year;

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
